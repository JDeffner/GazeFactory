using System;

namespace NPPImpl.NPPcomponents
{

    public class SteamValve : Component
    {
        /** True iff the valve is open */
        bool status = false;

        private String label;
        private int x;
        private int y;


        public SteamValve(bool blown, bool status)
        {
            this.status = status;
            this.blown = blown;
        }

        public bool getStatus()
        {
            return this.status;
        }

        public void setStatus(bool s)
        {
            if (!blown) this.status = s;
        }

        public bool isBlown()
        {
            return this.blown;
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