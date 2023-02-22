using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerAttachment
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private int damage;
        
        private bool hit;

        public Animator weaponAnimation;

        private void Start()
        {
            weaponAnimation = GetComponent<Animator>();
        }

        //Checks if the weapon animation is idle, if so attack (hit) is processed by OnTriggerEnter2D and OnTriggerStay2D
        private void Update()
        {
            if (weaponAnimation.GetCurrentAnimatorStateInfo(0).IsName("Idle Weapon"))
            {
                hit = false;
            }
        }
    
        //when sword (box collider) hits the enemy (another collider) and animation is played enemy gets damage
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag=="Player" && 
                weaponAnimation.GetCurrentAnimatorStateInfo(0).IsName("Slash") &&
                !hit)
            {
                // collision.gameObject.GetComponent<PlayerBody>().TakeDamage(damage);
                hit = true;
            }
        }

        //if weapon stay in touch with enemy, it is checked, if animation is executed and already hit once
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag=="Player" && 
                weaponAnimation.GetCurrentAnimatorStateInfo(0).IsName("Slash") &&
                !hit
               )
            {
                // collision.gameObject.GetComponent<PlayerBody>().TakeDamage(damage);
                hit = true;
            }
        }

    }
}