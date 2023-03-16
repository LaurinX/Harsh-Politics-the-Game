using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace PlayerAttachment 
{
    [Serializable]
    public class Health
    {
        [SerializeField]
        private int _maxHealth;

        [SerializeField]
        private int _health;
        
        private Slider _slider;

        private GameObject[] _hearts;
        
        private int _maxLeben = 3;

        private int _leben;

        public void SetSlider(Slider slider)
        {
            _slider = slider;
        }
        public void SetHealth()
        {
            _health = _maxHealth;
            _slider.maxValue = _maxHealth;
            _slider.value = _maxHealth;
        }

        public void SetLeben(GameObject[] hearts)
        {
            _hearts = hearts;
            _leben = _maxLeben;
        }
        
        public event EventHandler HealthConsumed;

        public event EventHandler LifeConsumed;

        public void DecreaseHealth(int amount)
        {
            _health -= amount;
            _slider.value = _health;
            if (_health <= 0)
            {
                _health = 0;
                HealthConsumed?.Invoke(this, EventArgs.Empty);
            }

        }
        public void DecreaseLeben()
        {
            _leben--;
            if (_leben > 0)
            {
                _hearts[_leben].SetActive(false);
            }
            if(_leben<= 0)
            {
                _leben = 0;
                _hearts[_leben].SetActive(false);
                LifeConsumed?.Invoke(this, EventArgs.Empty);
                //Gameover, VictorySzene;
            }
        }
    }
}

