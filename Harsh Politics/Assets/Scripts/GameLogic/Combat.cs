using DefaultNamespace;
using Entity;
using UnityEngine;

//attached to hand
namespace GameLogic
{
    public class Combat : MonoBehaviour
    {
        private PlayerControls _controls;

        private float holdTime = -1f;
        
        private bool charged = false;
        
        private void Start()
        {
            _controls = transform.GetComponentInParent<PlayerControls>();
        }

        private void Update()
        {
            if (Input.GetKey(_controls.attack))
            {
                //somehow it measures the time in seconds?
                holdTime += 1*Time.deltaTime;
                if (holdTime > 2f)
                {
                    charged = true;
                    holdTime = -1f;
                }

            }
            else
            {
                charged = false;
                holdTime = -1;
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (Input.GetKey(_controls.attack) &&
                collider.gameObject.tag == "Player")
                {
                    Attack(collider.transform);
                }

                if (charged)
                {
                    SpecialAttack();
                }
        }

        private void OnTriggerStay2D(Collider2D collider)
        {
            var compareTag = collider.gameObject.tag == "Player";
            if (Input.GetKey(_controls.attack)
                && compareTag)
                {
                    Attack(collider.transform);
                }

                if (Input.GetKey(_controls.attack) && charged)
                {
                    SpecialAttack();
                }
        }

        private void Attack(Transform enemy)
        {
            var damage = gameObject.GetComponent<Weapon>().GetDamageValue();
        
            enemy.gameObject.GetComponent<PlayerBody>().SendMessage("TakeDamage", damage);
        }

        private void SpecialAttack()
        {

        }

        private void Defense()
        {
        
        }

    }
}
