using System;
using System.Collections.Concurrent;

namespace ConsoleApp1
{

	public class Reactor : Component
	{
		private float waterLevel;
		private float pressure;
		private bool overheated;
		private int moderatorPercent;
		private int meltStage;
		private int coreTemperature;
		private int thermicOutput;
		private ConcurrentQueue<int> poiseningFactor;
		private String label;

		// critical values

		// water level
		public const int MIN_WATER_LEVEL = 700;
		public const int MAX_WATER_LEVEL = 2400;
		public const int LOWER_WATER_LEVEL_THRESHOLD = 1500;
		public const int CRITICAL_WATER_LEVEL_THRESHOLD = 1000;

		// pressure
		public const int MIN_PRESSURE = 1;
		public const int MAX_PRESSURE = 500;
		public const int UPPER_PRESSURE_THRESHOLD = 450;

		// temperature
		public const int MIN_TEMPERATURE = 20;
		public const int LOWER_THRESHOLD_TEMPERATURE = 200;
		public const int UPPER_THRESHOLD_TEMPERATURE = 300;
		public const int MAX_TEMPERATURE = 350;

		// view values
		private int x = 10;
		private int y = 425;

		public Reactor(int moderatorPosition, bool overheated, int meltStage, float pressure, float waterLevel,
			bool blow)
		{
			this.moderatorPercent = moderatorPosition;
			this.overheated = overheated;
			this.meltStage = meltStage;
			this.pressure = pressure;
			this.waterLevel = waterLevel;
			this.blown = blow;
			this.poiseningFactor = new ConcurrentQueue<int>();
			for (int i = 0; i < 100; i++) poiseningFactor.Enqueue(moderatorPercent);
//		System.out.println(poiseningFactor);
		}

		public void meltdown()
		{
			overheated = true;
			meltStage = 5;
		}

//	public void paintMeltdown(Graphics g) {
//
//		int x0 = -60, y0 = 110;
//		if (meltStage == 5)
//			g.drawImage(radiationSign, 170, 150, parentViz);
//		if (meltStage < 1500) {
//			int d = meltStage;
//			int x = Math.max(x0 - (d - 100), 0)
//					+ rand(0, Math.min(d, parentViz.getSize().width));
//			int y = Math.max(y0 - (d - 100), 0)
//					+ rand(0, Math.min(d, parentViz.getSize().height));
//			g.copyArea(x, y, rand(10, 100), rand(10, 100), ((d < 250) ? rand(-3, 3) : rand(-2, 2)), ((d < 250) ? rand(-3, 3) : rand(-2,2)));
//			meltStage++;
//		}
//	}
//
//	

		public int getModeratorPosition()
		{
			return this.moderatorPercent;
		}

		public void setModeratorPosition(int modpos)
		{
			this.moderatorPercent = modpos;
			try
			{
				for (int i = 0; i < 10; i++)
				{
					int item;
					poiseningFactor.TryDequeue(out item);
					poiseningFactor.Enqueue(modpos);
				}
			}
			catch
			{
				// Auto construct
			}
		}

		public bool isOverheated()
		{
			return overheated;
		}

		public void setOverheated(bool overh)
		{
			this.overheated = overh;
		}

		public int getMeltStage()
		{
			return meltStage;
		}

		public void setMeltStage(int meltSt)
		{
			this.meltStage = meltSt;
		}

		public float getPressure()
		{
			return pressure;
		}

		public void setPressure(float pressure)
		{
			this.pressure = pressure;
		}

		public float getWaterLevel()
		{
			return waterLevel;
		}

		public void setWaterLevel(float level)
		{
			this.waterLevel = level;
		}

		public bool isBlown()
		{
			return blown;
		}

		public override void update()
		{

		}

		public override void blow()
		{
			blown = true;
		}

		public int getPoisiningFactor()
		{
			int item;
			poiseningFactor.TryPeek(out item);
			int res = (item - moderatorPercent);
			return res;
		}
	}
}