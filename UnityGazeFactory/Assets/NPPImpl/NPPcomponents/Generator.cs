namespace NPPImpl.NPPcomponents
{

    public class Generator : Component
    {
        /** Output generator power (in MW) */
        private int power;



        public Generator(int power)
        {
            this.power = power;
        }

        public int getPower()
        {
            return power;
        }

        public void setPower(int p)
        {
            if (!blown) this.power = p;
            else this.power = 0;
        }

        public override void update()
        {

        }

        public override void blow()
        {
            blown = true;
        }
    }
}