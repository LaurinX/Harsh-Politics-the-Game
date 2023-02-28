using UnityEngine;

namespace Entities
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        private int damage;
        [SerializeField]
        private float attackSpeed = 1;
        
        private float destroytime = 5;

        private float counter = 0;

        private Collider2D _collider;
        
        public bool StrikeMode { get; set; } = false;
        
        public int GetDamageValue()
        {
            return damage;
        }

        public float GetAttackSpeed()
        {
            return attackSpeed;
        }

        public void CheckIfMasterExists()
        {
            if (transform.parent is null)
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