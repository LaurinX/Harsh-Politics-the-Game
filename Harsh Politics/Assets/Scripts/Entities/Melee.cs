using System;
using PlayerAttachment;
using UnityEngine;

namespace Entities
{
    public class Melee : Weapon
    {
        private float holdTime;

        private Collider2D _collider;

        private void Start()
        {
            _collider = gameObject.GetComponent<Collider2D>();
        }

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
                _collider.isTrigger = false;
            }
        }

        protected override void Animation()
        {
            if (holdTime >= 0.1f)
            {
                StrikeMode = false;
                _collider.isTrigger = true;
            }

        }
    }
}