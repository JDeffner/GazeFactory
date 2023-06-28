using System;

namespace NPPImpl.NPPcomponents
{

    public abstract class Component
    {
        /** True iff component broken */
        protected bool blown = false;

        public abstract void blow();

        public abstract void update();

        public bool isBlown()
        {
            return blown;
        }

        public static int rand(double min, double max)
        {
            Random random = new Random();
            return (int)(random.NextDouble() * (max - min) + min);
        }
    }
}