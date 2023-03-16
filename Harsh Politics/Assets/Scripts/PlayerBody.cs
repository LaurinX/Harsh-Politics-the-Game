using System;
using System.Collections.Generic;
using Entities;
using PlayerAttachment;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerBody : MonoBehaviour
    {
        public Health _health;

        public Armor _armor;

        private float knockbackForce = 3000;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponentInParent<Rigidbody2D>();

            //Creates a hand from prefab and attach it to player as child
            var hand = Instantiate(Resources.Load("Default/A_Hand") as GameObject, transform);
            hand.layer = gameObject.layer;

            var leben = Instantiate(Resources.Load("Leben/Health") as GameObject, transform);
            
            _health.SetSlider(leben.GetComponentInChildren<Slider>());
            
            _health.SetHealth();
            
            var herzen = new List<GameObject>();
            
            herzen.Add(leben.transform.GetChild(0).Find("1").gameObject);
            herzen.Add(leben.transform.GetChild(0).Find("2").gameObject);
            herzen.Add(leben.transform.GetChild(0).Find("3").gameObject);
            
            _health.SetLeben(herzen.ToArray());
            
            _health.HealthConsumed += HealthLost;
            _health.LifeConsumed += Destroybody;
        }

    

        private void OnDestroy()
        {
            _health.LifeConsumed -= Destroybody;
            _health.HealthConsumed -= HealthLost;
        }

        void Destroybody(object sender, EventArgs e)
        {
            Destroy(gameObject);
        }
        
        void HealthLost(object sender, EventArgs e)
        {
            _health.DecreaseLeben();
            //Reset HealthBar
            _health.SetHealth();
        }

        //Check weapon also over layer because collider box overlapping 
        private void OnCollisionEnter2D(Collision2D col)
        {
 
            if (col.relativeVelocity.magnitude > 40 &&
                col.gameObject.GetComponent<Weapon>())
            {
                KnockBack(col.transform);
                _health.DecreaseHealth(1);
            }

            if (col.gameObject.TryGetComponent(out Bullet bullet))
            {
                KnockBack(col.transform);
                _health.DecreaseHealth(bullet.BulletDamage());
            }
        }
        
        //Trigger interaction with box collider setTrigger = true;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out SpecialAbility ability))
            {
                KnockBack(ability.transform);
                _health.DecreaseHealth(3);
            }
                        
            if (col.gameObject.TryGetComponent(out Weapon weapon))
            {
                if (weapon.StrikeMode)
                {
                    KnockBack(weapon.transform);
                    
                    _health.DecreaseHealth(col.gameObject.GetComponent<Weapon>().GetDamageValue());
                }
            }
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out Weapon weapon))
            {
                if (weapon.StrikeMode)
                {
                    KnockBack(weapon.transform);
                    
                    _health.DecreaseHealth(col.gameObject.GetComponent<Weapon>().GetDamageValue());
                }
            }
        }

        private void KnockBack(Transform col)
        {
            Vector2 difference = (transform.position - col.position).normalized;
            Vector2 force = difference * knockbackForce;
            _rigidbody.AddForce(force, ForceMode2D.Force); 
        }
    }
}