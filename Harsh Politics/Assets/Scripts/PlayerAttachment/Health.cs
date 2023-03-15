using System;
using UnityEngine;
namespace PlayerAttachment 
{
    [Serializable]
    public class Health
    {
        [SerializeField]
        private int _maxHealth;

        [SerializeField]
        private int _health;


        [SerializeField]
        private int _maxLeben;

        [SerializeField]
        private int _Leben;

        public void SetHealth()
        {
            _health = _maxHealth;
        }
        public void SetLeben()
        {
            _Leben = _maxLeben;
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
        public void DecreaseLeben()
        {
            _Leben--;
            if(_Leben== 0)
            {
                //Gameover, VictorySzene;
            }
        }
    }
}

