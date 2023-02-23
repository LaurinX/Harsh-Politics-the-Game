using DefaultNamespace.InspectorSettings;
using UnityEngine;

namespace Entity
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private int damage;
        [SerializeField]
        private int attackSpeed;
        
        [ReadOnly]
        private bool hasMaster = false;

        private float destroytime = 5;

        private float counter = 0;

        private void Start()
        {
        }

        public int GetDamageValue()
        {
            return damage;
        }

        public int GetAttackSpeed()
        {
            return attackSpeed;
        }
        

        public void SetMaster(bool master)
        {
            hasMaster = master;
        }

        private void Update()
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


        // public Animator weaponAnimation;
        //
        // private void Start()
        // {
        //     weaponAnimation = GetComponent<Animator>();
        // }
        //
        // //Checks if the weapon animation is idle, if so attack (hit) is processed by OnTriggerEnter2D and OnTriggerStay2D
        // private void Update()
        // {
        //     if (weaponAnimation.GetCurrentAnimatorStateInfo(0).IsName("Idle Weapon"))
        //     {
        //         hit = false;
        //     }
        // }
        //
        // //when sword (box collider) hits the enemy (another collider) and animation is played enemy gets damage
        // private void OnTriggerEnter2D(Collider2D collision)
        // {
        //     if (collision.gameObject.tag=="Player" && 
        //         weaponAnimation.GetCurrentAnimatorStateInfo(0).IsName("Slash") &&
        //         !hit)
        //     {
        //         // collision.gameObject.GetComponent<PlayerBody>().TakeDamage(damage);
        //         hit = true;
        //     }
        // }
        //
        // //if weapon stay in touch with enemy, it is checked, if animation is executed and already hit once
        // private void OnTriggerStay2D(Collider2D collision)
        // {
        //     if (collision.gameObject.tag=="Player" && 
        //         weaponAnimation.GetCurrentAnimatorStateInfo(0).IsName("Slash") &&
        //         !hit
        //        )
        //     {
        //         // collision.gameObject.GetComponent<PlayerBody>().TakeDamage(damage);
        //         hit = true;
        //     }
        // }
    }
}