using System;
using DefaultNamespace.InspectorSettings;
using UnityEngine;

namespace PlayerAttachment
{
    [Serializable]
    public class Health
    {
        [SerializeField]
        private int _maxHealth;
        [ReadOnly]
        [SerializeField]
        private int _health;

        public void SetHealth()
        {
            _health = _maxHealth;
        }

        public event EventHandler LifeConsumed;

        public void DecreaseHealth(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                _health = 0;
                LifeConsumed?.Invoke(this, EventArgs.Empty);
            }

        }
    }
}

