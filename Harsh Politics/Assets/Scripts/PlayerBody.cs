using System;
using PlayerAttachment;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerBody: MonoBehaviour
    {
        [SerializeField]
        public Health _health;
        //Armor
        //Hand - Weapon 
        private void Start()
        {
            _health.SetHealth();
            _health.LifeConsumed += Destroybody;
        }

        private void Update()
        {
        }
        
        void Destroybody(object sender, EventArgs e)
        {
            Destroy(gameObject);
        }
    }
}