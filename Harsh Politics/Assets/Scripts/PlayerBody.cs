using System;
using Entities;
using PlayerAttachment;
using SupportFiles;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerBody : MonoBehaviour
    {
        public Health _health;

        public Armor _armor;
        
        private float knockbackForce = 1500;

        private void Start()
        {
            
            //Creates a hand from prefab and attach it to player as child
            Instantiate(Resources.Load("Default/A_Hand") as GameObject, transform);
            
            _health.SetHealth();
            _health.LifeConsumed += Destroybody;
        }

        private void OnDestroy()
        {
            _health.LifeConsumed -= Destroybody;
        }

        void Destroybody(object sender, EventArgs e)
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.relativeVelocity.magnitude > 20 &&
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

        private void OnTriggerEnter2D(Collider2D col)
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
            gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force); 
        }
    }
}