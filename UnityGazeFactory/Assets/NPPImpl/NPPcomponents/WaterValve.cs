namespace ConsoleApp1
{

    public class WaterValve : Component
    {
        bool status = false;

        public WaterValve(bool blown, bool status)
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
            // used in Java for JComponent -> GUI
            // if (s != this.status) {
            //     firePropertyChange("status", this.status, s);
            // }
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