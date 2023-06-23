namespace NPPImpl.NPPcomponents
{

    public class Condenser : Component
    {
        private float waterLevel;
        private float pressure;
        public const int MIN_WATER_LEVEL = 300;
        public const int MAX_WATER_LEVEL = 5000;
        public const int LOWER_WATER_LEVEL_THRESHOLD = 2000;
        public const int MIN_PRESSURE = 0;
        public const int MAX_PRESSURE = 140;
        public const int UPPER_PRESSURE_THRESHOLD = 120;

        public Condenser(int waterLevel, int pressure, bool blown)
        {
            this.waterLevel = waterLevel;
            this.pressure = pressure;
            this.blown = blown;
        }

        public float getWaterLevel()
        {
            return waterLevel;
        }

        public void setWaterLevel(float level)
        {
            this.waterLevel = level;
        }

        public float getPressure()
        {
            return pressure;
        }

        public void setPressure(float pressure)
        {
            this.pressure = pressure;
        }

        public bool isBlown()
        {
            return blown;
        }

        public override void blow()
        {
            blown = true;
        }

        public override void update()
        {

        }
    }
}