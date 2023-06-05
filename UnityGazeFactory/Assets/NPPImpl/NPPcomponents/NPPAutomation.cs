using System;
using System.Threading;
using ConsoleApp1;

public class NPPAutomation
{
    private NPPSystemInterface simulator;
    private Thread automationThread;

    private bool scram;
    private int deltaWL;
    private int waterPumpStepSize = 100;

    public NPPAutomation(NPPSystemInterface simulator)
    {
        this.simulator = simulator;
        this.scram = false;
    }

    public void Start()
    {
        if (automationThread == null)
        {
            automationThread = new Thread(Run);
            automationThread.Name = "NPPAutomationThread";
            automationThread.Start();
        }
    }

    public void Run()
    {
        int wl1 = simulator.getWaterLevelReactor();

        while (simulator.isSimulationRunning())
        {
            if (simulator.getWaterLevelReactor() > 2500 || simulator.getWaterLevelReactor() < 1900)
            {
                deltaWL = simulator.getWaterLevelReactor() - wl1;
                Console.WriteLine(deltaWL);

                if (deltaWL < 0)
                {
                    int newRPM = this.simulator.getWP1RPM() +
                                 (Math.Abs(deltaWL) + Math.Abs(this.simulator.getWaterLevelReactor() - 2200));
                    if (this.simulator.getWaterLevelReactor() < 2200)
                    {
                        if (newRPM >= 0)
                            this.simulator.setWP1RPM(newRPM);
                    }
                }
                else if (deltaWL > 0)
                {
                    int newRPM = this.simulator.getWP1RPM() -
                                 (Math.Abs(deltaWL) + Math.Abs(this.simulator.getWaterLevelReactor() - 2200));
                    if (this.simulator.getWaterLevelReactor() > 2200)
                    {
                        if (newRPM >= 0)
                            this.simulator.setWP1RPM(newRPM);
                    }
                }
                else
                {
                    if (this.simulator.getWaterLevelReactor() > 2200)
                        this.simulator.setWP1RPM(0);
                    if (this.simulator.getWaterLevelReactor() < 1800)
                        this.simulator.setWP1RPM(1800);
                }
            }

            if (simulator.getWaterLevelReactor() > 2800 || simulator.getWaterLevelReactor() < 1500)
                this.simulator.setReactorModeratorPosition(0);

            wl1 = simulator.getWaterLevelReactor();

            try
            {
                Thread.Sleep(250);
            }
            catch
            {
            }
        }
    }
}
