using System;
using PlayerAttachment;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerBody: MonoBehaviour
    {
        public Health _health;
        
        public Armor _armor;

        private Hand _hand;

        private PlayerCombat _combat;

        
        
        private void Start()
        {
            //Creates a hand from prefab and attach it to player as child
            var hand = Instantiate(Resources.Load("Default/A_Hand") as GameObject, transform);
            hand.name = "Hand";
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