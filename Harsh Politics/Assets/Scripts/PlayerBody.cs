using System;
using Entities;
using GameLogic;
using PlayerAttachment;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerBody : MonoBehaviour
    {
        public Health _health;

        public Armor _armor;

        private Hand _hand;
        
        private PlayerControls _controls;

        private bool _rightKey;

        private bool _leftKey;

        private bool faceDirection;

        private void Start()
        {
            //Creates a hand from prefab and attach it to player as child
            var hand = Instantiate(Resources.Load("Default/A_Hand") as GameObject, transform);
            hand.name = "Hand";
            _controls = GetComponent<PlayerControls>();
            _health.SetHealth();
            _health.LifeConsumed += Destroybody;

            _rightKey = true;

        }

        public bool CurrentFaceDirection()
        {
            return faceDirection;
        }

        private void Update()
        {
            if (Input.GetKey(_controls.right) &&
                !_rightKey)
            {
                transform.Find("Hand").RotateAround(transform.position, Vector3.up, 180f);
                _rightKey = true;
                _leftKey = false;
                faceDirection = false;
            }

            if (Input.GetKey(_controls.left) &&
                !_leftKey)
            {
                transform.Find("Hand").RotateAround(transform.position, Vector3.down, 180f);
                _rightKey = false;
                _leftKey = true;
                faceDirection = true;
            }
        }


        private void OnDestroy()
        {
            _health.LifeConsumed -= Destroybody;
        }

        public void TakeDamage(int damage)
        {
            _health.DecreaseHealth(damage);
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
                _health.DecreaseHealth(1);
            }

            if (col.gameObject.GetComponent<Weapon>().StrikeMode)
            {
                _health.DecreaseHealth(col.gameObject.GetComponent<Weapon>().GetDamageValue());
            }

            if (col.gameObject.GetComponent<Bullet>())
            {
                _health.DecreaseHealth(col.gameObject.GetComponent<Bullet>().BulletDamage());
            }
        }

    }
}