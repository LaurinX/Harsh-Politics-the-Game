using UnityEngine;

namespace Entities
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        private int damage;
        [SerializeField]
        private float attackSpeed = 1;
        
        private bool hasMaster = false;

        private float destroytime = 5;

        private float counter = 0;
        
        public bool StrikeMode { get; set; } = false;
        
        public int GetDamageValue()
        {
            return damage;
        }

        public float GetAttackSpeed()
        {
            return attackSpeed;
        }
        
        public void SetMaster(bool master)
        {
            hasMaster = master;
        }

        public void CheckIfMasterExists()
        {
            if (!hasMaster)
            {
                counter += 1 * Time.deltaTime;
                if (counter >= destroytime)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                counter = 0;
            }
        }
        
        public abstract void Attack();

        protected abstract void Animation();
        
    }
}