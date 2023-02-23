using System;
using DefaultNamespace;
using Entity;
using Unity.VisualScripting;
using UnityEngine;

//attached to hand
namespace GameLogic
{
    public class Combat : MonoBehaviour
    {
        private PlayerControls _controls;

        private bool isTouching = false;

        private Transform _enemy;

        private float holdTime = 0;
        
        private bool charged = false;

        private int coolDown;
        
        private void Start()
        {
            _controls = transform.GetComponentInParent<PlayerControls>();
            coolDown = gameObject.GetComponent<Weapon>().GetAttackSpeed();
        }

        private void Update()
        {
            
            if (Input.GetKey(_controls.attack))
            {
                Debug.LogError("Press F");
                if (isTouching)
                {
                    Attack(_enemy);
                }
                //somehow it measures the time in seconds?
                holdTime += 1*Time.deltaTime;
                if (holdTime > 2f)
                {
                    holdTime = 0;
                }

            }
            else
            {
                charged = false;
                holdTime = 0;
            }
        }
        
        //Because This is the physics engine and it reacts more slowly than Update, which is per frame

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.gameObject.tag == "Player")
            {
                collision.transform.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
                _enemy = collision.transform;
                isTouching = true;       
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            Debug.LogError("notPlayer");
            if (collision.transform.gameObject.tag == "Player")
            {
                _enemy = collision.transform;
                isTouching = true;
                Debug.LogError("Stay");
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.gameObject.tag == "Player")
            {
                collision.transform.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;
                _enemy = null;
                isTouching = false;       
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
