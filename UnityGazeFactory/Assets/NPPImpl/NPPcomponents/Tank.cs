namespace NPPImpl.NPPcomponents
{

    public class Tank : Component
    {
        private float pressure;
        private float waterLevel;

        /** Blow up the tank */
        public override void blow()
        {
            blown = true;
        }

        public override void update()
        {

        }
    }
}