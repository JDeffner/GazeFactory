using UnityEngine;
using UnityEngine.ProBuilder;

namespace DefaultNamespace
{
    public class controllingWP1accordingToRods : MonoBehaviour
    {
        private bool moin = true;
        private int var1 = 2000;
        private int tmp = 2000;
        private float delay = 0.3f;
        private float counter = 0f;
        public bool isSinking = false;
        public int dCalc = 0;
        private int i = 0;
        public void Update()
        {
            counter += Time.deltaTime;
            if (counter >= delay)
            {
                tmp = var1;
                var1 = ControllerCubeBehaviour.nppSystemInterface.getWaterLevelReactor();

                if (tmp - var1 > 0)
                {
                    isSinking = true;
                }
                else
                {
                    isSinking = false;
                }

                i = tmp - var1;
                if (i < 0)
                {
                    dCalc = i * (-1);
                }
                else
                {
                    dCalc = i;
                }
                counter = 0f;
            }
        }
    }
}