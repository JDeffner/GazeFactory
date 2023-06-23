namespace NPPImpl.NPPcomponents
{

    public class Pump : Component
    {
        /** The state of the pump (0=crashed) */
        private int rpm;

        private int varSetRPM;
        private int blowcounter;
        private int upperRpmThreshold;
        private int maxRpm;

        private const int BLOW_COUNTER_INIT = 200;


        public Pump(int rpm, int maxRpm, int upperRpmThreshold, bool blown)
        {
            this.rpm = rpm;
            this.varSetRPM = rpm;
            this.upperRpmThreshold = upperRpmThreshold;
            this.maxRpm = maxRpm;
            this.blown = blown;
            this.blowcounter = BLOW_COUNTER_INIT;
        }

        /** Blow up the pump */
        public override void blow()
        {
            rpm = 0;
            varSetRPM = 0;
            blown = true;
        }

        public override void update()
        {
            if (!isBlown())
            {
                if (rpm > upperRpmThreshold) blowcounter--;
                else if (blowcounter < BLOW_COUNTER_INIT) blowcounter++;
                if (blowcounter < 0) blow();
                if (rpm != varSetRPM)
                    if (rpm > varSetRPM) rpm = varSetRPM + ((rpm - varSetRPM) / 2);
                    else rpm = varSetRPM - ((varSetRPM - rpm) / 2);
            }
        }

        public int getRPM()
        {
            return rpm;
        }

        public void setRPM(int rpm)
        {
//		if ( !isBlown() ) this.rpm = rpm;
            if (!isBlown()) varSetRPM = rpm;
            else this.rpm = 0;
        }

        public int getSetRPMN()
        {
            return varSetRPM;
        }

        public int getUpperRPMThreshold()
        {
            return upperRpmThreshold;
        }

        public int getMaxRPM()
        {
            return maxRpm;
        }
    }
}