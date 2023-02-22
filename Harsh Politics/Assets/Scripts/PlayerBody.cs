using System;
using PlayerAttachment;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerBody: MonoBehaviour
    {
        public Health _health;
        
        public Armor _armor;

        private PlayerCombat _combat;

        
        
        private void Start()
        {
            _combat = GetComponent<PlayerCombat>();
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
       
    }
}