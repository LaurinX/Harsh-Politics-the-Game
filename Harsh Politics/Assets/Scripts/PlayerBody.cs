using System;
using DefaultNamespace.PickUpSystem;
using PlayerAttachment;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerBody: MonoBehaviour
    {
        public Health _health;
        
        public Armor _armor;

        public Hand _hand;

        private void Start()
        {
            _health.SetHealth();
            _hand = new Hand();
            _health.LifeConsumed += Destroybody;
            var test = gameObject.transform.GetChild(0);
            test.gameObject.SetActive(false);
        }
        

        private void OnDestroy()
        {
            _health.LifeConsumed -= Destroybody;
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