using System;

namespace Entities
{
    public class Melee : Weapon
    {
        private void Update()
        {
            CheckIfMasterExists();
        }

        public override void Attack()
        {
            if (!StrikeMode)
            {
                StrikeMode = true;
                Animation();
            }
        }

        protected override void Animation()
        {
            
            StrikeMode = false;
        }
    }
}