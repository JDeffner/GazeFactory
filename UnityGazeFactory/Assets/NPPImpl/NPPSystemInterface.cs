using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Threading;

namespace ConsoleApp1
{

	public class NPPSystemInterface
	{

		private Thread nppSimulatorThread = null;

		private NPPAutomation automation;

		private Reactor reactor;
		private SteamValve SV1, SV2;
		private WaterValve WV1, WV2;
		private Pump WP1, WP2, CP;
		private Turbine turbine;
		private Condenser condenser;
		private Generator generator;

		private List<Component> components;

		private bool open = true;

		private int restheat = 0;

		private StreamWriter logstream;

		private long tempTime;

		private long countdownPump = 210000;
		private long countdownTurbine = 270000;
		private long countdownSAA, countdownSAB, countdownSAC;
		private bool flagA, flagB, flagC;

		private int pumpDamage = 0;
		private int turbineDamage = 1;
		private int saTest = 2;
		private static readonly int normalState = 3;

		private int STATE = normalState;
		private bool wait = false;

		private bool log = true;

// Simulation parameter

		public static readonly int PRESSURE_MAX_THRESHOLD_REACTOR = 400;
		public static readonly int PRESSURE_MAX_THRESHOLD_TRUBINE = 400;
		public static readonly int PRESSURE_MAX_THRESHOLD_CONDENSER = 200;
		public static readonly int WATERLEVEL_MAX_THRESHOLD_REACTOR = 4000;
		public static readonly int WATERLEVEL_MIN_THRESHOLD_REACTOR = 1500;
		public static readonly int WATERLEVEL_MAX_THRESHOLD_CONDENSER = 4000;

		public static readonly int RESTHEAT = 200;
		public static readonly double RESTHEAT_REDUCING_FACTOR = 0.0001;

		public void Close()
		{
			nppSimulatorThread = null;
			open = false;
			try
			{
				if (logstream != null)
				{
					logstream.Flush();
					logstream.Close();
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e.StackTrace);
			}

			GC.Collect();
		}

		public void Init()
		{
			components = new List<Component>();

			InitSimulation();

			STATE = normalState;
			tempTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
			Start();
			automation = new NPPAutomation(this);
			automation.Start();
		}

		public void Start()
		{
			if (nppSimulatorThread == null)
			{
				nppSimulatorThread = new Thread(Run);
				nppSimulatorThread.Name = "NPPSystemInterfaceThread";
				nppSimulatorThread.Start();
			}
		}

		protected void InitSimulation()
		{
			reactor = new Reactor(100, false, 1, 0, 2000, false);
			components.Add(reactor);
			SV1 = new SteamValve(false, false);
			components.Add(SV1);
			SV2 = new SteamValve(false, false);
			components.Add(SV2);
			WV1 = new WaterValve(false, false);
			components.Add(WV1);
			WV2 = new WaterValve(false, false);
			components.Add(WV2);
			WP1 = new Pump(0, 2000, 1800, false);
			components.Add(WP1);
			WP2 = new Pump(0, 2000, 1800, false);
			components.Add(WP2);
			CP = new Pump(0, 2000, 1800, false);
			components.Add(CP);
			turbine = new Turbine(false);
			components.Add(turbine);
			condenser = new Condenser(4000, 0, false);
			components.Add(condenser);
			generator = new Generator(0);
			components.Add(generator);
		}


		protected void timeStep(int n)
		{
			float v1, v2, v3, v4;

			if (!wait)
			{

				for (int i = 0; i < n; i++)
				{
					if (!reactor.isOverheated())
					{
						// Compute the flow through valve_1...
						if (SV1.getStatus())
							v1 = (reactor.getPressure() - condenser.getPressure()) / 10;
						else
							v1 = 0;
						// Compute the flow through valve_2...
						if (SV2.getStatus())
							v2 = (reactor.getPressure() - condenser.getPressure()) / 2.5f;
						else
							v2 = 0;

						// Compute the flow through valve_3 and pump_1...
						if (WV1.getStatus())
						{
							if (WP1.getRPM() > 0)
							{
								if (condenser.getWaterLevel() > 0)
									v3 = WP1.getRPM() * 0.07f;
								else
									v3 = 0;
							}
							else
							{
								if (condenser.getWaterLevel() > 0 &&
								    (condenser.getWaterLevel() - reactor.getWaterLevel()) > 470
								    && (SV1.getStatus() || SV2.getStatus())) v3 = 2f;
								else if (condenser.getWaterLevel() > 0 &&
								         (condenser.getWaterLevel() - reactor.getWaterLevel()) < 470
								         && (SV1.getStatus() || SV2.getStatus())) v3 = -2f;
								else v3 = 0;
							}

							if (reactor.getWaterLevel() >= (Reactor.MAX_WATER_LEVEL + 500) && !SV1.getStatus()) v3 = 0;
						}
						else v3 = 0;

						// Compute the flow through valve_4 and pump_2...
						if (WV2.getStatus())
						{
							if (WP2.getRPM() > 0)
							{
								if (condenser.getWaterLevel() > 0)
									v4 = WP2.getRPM() * 0.07f;
								else
									v4 = 0;
							}
							else
							{
								if (condenser.getWaterLevel() > 0 &&
								    (condenser.getWaterLevel() - reactor.getWaterLevel()) > 470
								    && (SV1.getStatus() || SV2.getStatus())) v4 = 2f;
								else if (condenser.getWaterLevel() > 0 &&
								         (condenser.getWaterLevel() - reactor.getWaterLevel()) < 470
								         && (SV1.getStatus() || SV2.getStatus())) v4 = -2f;
								else v4 = 0;
							}

							if (reactor.getWaterLevel() >= (Reactor.MAX_WATER_LEVEL + 500) && !SV1.getStatus()) v4 = 0;
						}
						else v4 = 0;

						// Scale the flow levels to allow frequent time steps
						// (smother animation)
						float factor = 0.5f;
						v1 *= factor;
						v2 *= factor;
						v3 *= factor;
						v4 *= factor;

						// Compute new values for pressure and water levels...
						float poison = reactor.getPoisiningFactor() / 5;
						float boiledRW = ((100 - reactor.getModeratorPosition()) * 2 * (900 - reactor.getPressure()) /
						                  620);
						if (reactor.getModeratorPosition() == 100)
						{
							restheat = (int)(restheat / (1 + RESTHEAT_REDUCING_FACTOR));
							if (poison > 0) boiledRW = (boiledRW + restheat) * factor * poison;
							else boiledRW = (boiledRW + restheat) * factor;
						}
						else
						{
							restheat = RESTHEAT - (2 * reactor.getModeratorPosition());
							if (poison > 0) boiledRW = boiledRW * factor * poison;
							else boiledRW = boiledRW * factor;

						}

						float cooledKP = (float)(CP.getRPM() * Math.Sqrt(condenser.getPressure()) * 0.003f);
						cooledKP *= factor;

						float newRP = reactor.getPressure() - v1 - v2 + boiledRW / 4;

						// The steam flow to the condenser stops if the
						// turbine is blown...
						if (turbine.isBlown()) v1 = 0;

						// Compute new values for pressure and water levels...
						float newKP = condenser.getPressure() + v1 + v2 - cooledKP;
						float newRW = reactor.getWaterLevel() + v3 + v4 - boiledRW;
						float newKW = condenser.getWaterLevel() - v3 - v4 + 4 * cooledKP;

						// Make adjustments for blown tanks...
						if (reactor.isBlown()) newRP = 0.15f * newRP;
						if (condenser.isBlown()) newKP = 0.2f * newKP;

						// Check the computed values for illegal values...
						if (newKW < 0) newKW = 0;
						if (newKW > 9600) newKW = 9600;
						if (newRW > 4700) newRW = 4700;
						if (newKP < 0) newKP = 0;
						if (newKP > 300) newKP = 300;
						if (newRP > 800) newRP = 800;

						// Adjust the generator power...
						float newEffect;
						if (SV1.getStatus() && !turbine.isBlown())
							newEffect = (newRP - newKP) * 2.5f;
						else
							newEffect = 0;

						// Assign the computed values...
						generator.setPower((int)newEffect);
						condenser.setPressure(newKP);
						condenser.setWaterLevel(newKW);
						reactor.setPressure(newRP);
						reactor.setWaterLevel(newRW);

						// RULES
						if (WP1.isBlown()) WP1.setRPM(0);
						if (WP2.isBlown()) WP2.setRPM(0);
						if (CP.isBlown()) CP.setRPM(0);

						if (reactor.getWaterLevel() < Reactor.CRITICAL_WATER_LEVEL_THRESHOLD) reactor.meltdown();
						if (reactor.getPressure() >= Reactor.MAX_PRESSURE) reactor.blow();
						if (reactor.getWaterLevel() > (Reactor.MAX_WATER_LEVEL + 500) && SV1.getStatus())
							turbine.blow();

						if (condenser.getWaterLevel() <= Condenser.MIN_WATER_LEVEL && WP1.getRPM() > 0) WP1.blow();
						if (condenser.getWaterLevel() <= Condenser.MIN_WATER_LEVEL && WP2.getRPM() > 0) WP2.blow();
						if (condenser.getPressure() >= Condenser.MAX_PRESSURE) condenser.blow();
						if (condenser.getWaterLevel() > Condenser.MAX_WATER_LEVEL + 300) turbine.blow();

					}

					foreach (Component component in components)
					{
						component.update();
					}

					if (log) logSystemState(null);

					if (STATE == pumpDamage && !WP1.isBlown())
					{
						long tt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
						long diff = (tt - tempTime);
						countdownPump = countdownPump - diff;
						if (countdownPump < 0) WP1.blow();
						tempTime = tt;
					}

					if (STATE == turbineDamage && !turbine.isBlown())
					{
						long tt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
						long diff = (tt - tempTime);
						if (countdownTurbine < 0) turbine.blow();
						countdownTurbine = countdownTurbine - diff;
						tempTime = tt;
					}

					if (STATE == saTest)
					{
						long tt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
						long diff = (tt - tempTime);
						if (countdownSAA > 0)
						{
							countdownSAA = countdownSAA - diff;
						}
						else if (countdownSAA <= 0 && flagA)
						{
							flagA = false;
							stopp();
							return;
						}

						if (countdownSAB > 0 && !flagA)
						{
							countdownSAB = countdownSAB - diff;
						}
						else if (countdownSAB <= 0 && flagB)
						{
							flagB = false;
							stopp();
							return;
						}

						if (countdownSAC > 0 && !flagA && !flagB)
						{
							countdownSAC = countdownSAC - diff;
						}
						else if (countdownSAC <= 0 && flagC)
						{
							flagC = false;
							stopp();
							return;
						}

						tempTime = tt;
					}

					try
					{
						Thread.Sleep(200);
					}
					catch (ThreadInterruptedException e)
					{
					}
				}
			}

		}




		public void Run()
		{
			while (open)
			{
				this.timeStep(1);
			}

		}

		public void stopp()
		{
			logSystemState("Stopp");
			wait = true;
		}

		public bool isSimulationRunning()
		{
			return !wait;
		}

/*
 * Interface implementiation for contorlling from outside
 */

///// SETTER

		public void setReactorModeratorPosition(int pos)
		{
			if (pos > 100) pos = 100;
			if (pos < 0) pos = 0;
			this.reactor.setModeratorPosition(100 - pos);
		}

		public void setWP1RPM(int rpm)
		{
			this.WP1.setRPM(rpm);
		}

		public void setWP2RPM(int rpm)
		{
			this.WP2.setRPM(rpm);
		}

		public void setCPRPM(int rpm)
		{
			this.CP.setRPM(rpm);
		}

		public void setSV1Status(Boolean st)
		{
			try
			{
				Thread.Sleep(500);
			}
			catch (ThreadInterruptedException e)
			{
			}

			this.SV1.setStatus(st);
		}

		public void setSV2Status(Boolean st)
		{
			try
			{
				Thread.Sleep(500);
			}
			catch (ThreadInterruptedException e)
			{
			}

			this.SV2.setStatus(st);
		}

		public void setWV1Status(Boolean st)
		{
			try
			{
				Thread.Sleep(500);
			}
			catch (ThreadInterruptedException e)
			{
			}

			this.WV1.setStatus(st);
		}

		public void setWV2Status(Boolean st)
		{
			try
			{
				Thread.Sleep(500);
			}
			catch (ThreadInterruptedException e)
			{
			}

			this.WV2.setStatus(st);
		}

		/// GETTER

		public Boolean getWP1Status()
		{
			return !WP1.isBlown();
		}

		public int getWP1RPM()
		{
			return WP1.getRPM();
		}

		public Boolean getWP2Status()
		{
			return !WP2.isBlown();
		}

		public int getWP2RPM()
		{
			return WP2.getRPM();
		}

		public Boolean getCPStatus()
		{
			return !CP.isBlown();
		}

		public int getCPRPM()
		{
			return CP.getRPM();
		}

		public Boolean getWV1Status()
		{
			return WV1.getStatus();
		}

		public Boolean getWV2Status()
		{
			return WV2.getStatus();
		}

		public Boolean getSV1Status()
		{
			return SV1.getStatus();
		}

		public Boolean getSV2Status()
		{
			return SV2.getStatus();
		}

		public int getWaterLevelReactor()
		{
			return (int)reactor.getWaterLevel();
		}

		public int getWaterLevelCondenser()
		{
			return (int)condenser.getWaterLevel();
		}

		public int getPressureReactor()
		{
			return (int)reactor.getPressure();
		}

		public int getPressureCondenser()
		{
			return (int)condenser.getPressure();
		}

		public int getStandardValue()
		{
			return 12;
		}

		public int getPowerOutlet()
		{
			return generator.getPower();
		}

		public Boolean getReactorTankStatus()
		{
			return !reactor.isBlown();
		}

		public Boolean getReactorStatus()
		{
			return !reactor.isOverheated();
		}

		public Boolean getCondenserStatus()
		{
			return !condenser.isBlown();
		}

		public Boolean getTurbineStatus()
		{
			return !turbine.isBlown();
		}

		public Boolean getKPStatus()
		{
			return !CP.isBlown();
		}

		public Boolean getAtomicStatus()
		{
			if (reactor.isOverheated() && (
				    reactor.isBlown() || condenser.isBlown() || turbine.isBlown())) return !true;
			else return !false;
		}

		public int getRodPosition()
		{
			return reactor.getModeratorPosition();
		}

		public int getWP1RPMSet()
		{
			return WP1.getSetRPMN();
		}

		public int getWP2RPMSet()
		{
			return WP2.getSetRPMN();
		}

		public int getCPRPMSet()
		{
			return CP.getSetRPMN();
		}

		private void logSystemState(string info)
		{
		}
	}
}