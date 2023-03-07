using System;
using PlayerAttachment;
using UnityEngine;

namespace Entities
{
    public class Melee : Weapon
    {
        private float holdTime;
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
                anim.SetTrigger("attack");

                _collider.isTrigger = false;
            }
        }
        protected override void Animation()
        {
            if (holdTime >= 0.1f)
            {
                StrikeMode = false;
                gameObject.GetComponent<Collider2D>().isTrigger = true;     
                _collider.isTrigger = true;
            }

        }
    }
}