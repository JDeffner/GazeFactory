namespace NPPImpl.NPPcomponents
{

    public class Turbine : Component
    {
        public Turbine(bool blown)
        {
            this.blown = blown;
        }

        public override void blow()
        {
            blown = true;
        }

        public bool isBlown()
        {
            return this.blown;
        }

        public override void update()
        {

        }
    }
}