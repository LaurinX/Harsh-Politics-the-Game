using System;
using PlayerAttachment;
using UnityEngine;

namespace Entities
{
    public class Melee : Weapon
    {
        private float animationTime;
        
        public Animator anim;
        private Collider2D _collider;

        private void Start()
        {
            _collider = gameObject.GetComponent<Collider2D>();
        }
		
        private void Update()
        {
            if (CheckIfMasterExists() == false) {
                GetComponent<Animator>().enabled = false;
            }
            else
            {
                GetComponent<Animator>().enabled = true;
            }
            if (StrikeMode)
            {
                animationTime += 1f * Time.deltaTime;
                Animation();
            }
            else
            {
                animationTime = 0;
            }
        }
        public override void Attack()
        {
            if (!StrikeMode)
            {
                StrikeMode = true;
                anim.SetTrigger("attack");

                _collider.isTrigger = false;
            }
        }
        protected override void Animation()
        {
            if (animationTime >= 0.1f)
            {
                StrikeMode = false;
                _collider.isTrigger = true;
            }

        }
    }
}