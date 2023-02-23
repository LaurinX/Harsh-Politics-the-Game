using System;
using System.Collections;
using UnityEngine;

namespace PlayerAttachment
{
    public class Hand : MonoBehaviour
    {
        private PlayerControls _controls;

        private bool _rightKey;

        private bool _leftKey;

        private bool _fistActive;

        private Transform _currentWeapon;
        
        private float holdTime = 0; 

        private void Start()
        {
            CreateDefaultWeapon();
            
            _controls = transform.parent.GetComponent<PlayerControls>();
            
            _fistActive = true;

            //because it's already facing right in the beginning
            _rightKey = true;

        }

        private void Update()
        {
            //Holding interaction key for 3 seconds causes a drop of the current weapon
            if (Input.GetKey(_controls.interaction))
            {
                //somehow it measures the time in seconds?
                holdTime += 1*Time.deltaTime;
                if (holdTime > 2f)
                {
                    DropWeapon(_currentWeapon);

                    holdTime = 0;
                }
            }
            else
            {
                holdTime = 0;
            }
            
            //TODO:refactor -> KeyControls and Weapon Drop/PickUp has to be in different classes
            if (Input.GetKey(_controls.right) &&
                !_rightKey)
            {
                transform.RotateAround(transform.parent.position, Vector3.up, 180f);
                _rightKey = true;
                _leftKey = false;
            }
            if(Input.GetKey(_controls.left) &&
               !_leftKey)
            {
                transform.RotateAround(transform.parent.position, Vector3.down, 180f);
                _rightKey = false;
                _leftKey = true;
            }
        }
        
        private void ChangeWeapon_new(Transform weapon)
        {
            if (_currentWeapon != null)
            {
                DropWeapon(_currentWeapon);
            }
            Destroy(weapon.GetComponent<Rigidbody2D>());
            weapon.GetComponent<Weapon>().SetMaster(true);
            weapon.SetParent(transform, false);
            weapon.localPosition = Vector3.zero;
            _currentWeapon = weapon;
            SetDefaultWeapon(false);
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (Input.GetKey(_controls.interaction) &&
                col.gameObject.tag == "Weapon")
            {
                ChangeWeapon_new(col.transform);
            }
        }

        private void DropWeapon(Transform weapon)
        {
            weapon.gameObject.AddComponent<Rigidbody2D>();
            weapon.gameObject.GetComponent<Collider2D>().isTrigger = false;
            weapon.gameObject.GetComponent<Weapon>().SetMaster(false);
            weapon.parent = null;
            SetDefaultWeapon(true);
        }

        private void CreateDefaultWeapon()
        {
            //Creates a Fist
            var fist = Instantiate(Resources.Load("Default/Fist") as GameObject, transform);
            fist.GetComponent<Weapon>().SetMaster(true);
            //renaming 
            fist.name = "Fist";
        }

        private void SetDefaultWeapon(bool modus)
        {
            transform.GetChild(0).gameObject.SetActive(modus);
            _fistActive = modus;
        }
    }
}