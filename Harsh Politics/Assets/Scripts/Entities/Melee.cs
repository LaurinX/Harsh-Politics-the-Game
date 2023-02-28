using UnityEngine;

namespace Entities
{
    public class Melee : Weapon
    {
        private float holdTime;
        private void Update()
        {
            CheckIfMasterExists();
            if (StrikeMode)
            {
                holdTime += 1 * Time.deltaTime;
                Animation();
            }
            else
            {
                holdTime = 0;
            }
        }

        public override void Attack()
        {
            if (!StrikeMode)
            {
                StrikeMode = true;
                gameObject.GetComponent<Collider2D>().isTrigger = false;
            }
        }

        protected override void Animation()
        {
            if (holdTime >= 0.1f)
            {
                StrikeMode = false;
                gameObject.GetComponent<Collider2D>().isTrigger = true;
            }

        }
    }
}