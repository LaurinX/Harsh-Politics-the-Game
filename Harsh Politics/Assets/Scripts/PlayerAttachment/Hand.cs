using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerAttachment
{
    public class Hand : MonoBehaviour
    {
        private PlayerControls _controls;

        private void Start()
        {
            _controls = transform.parent.parent.GetComponent<PlayerControls>();

            DeactivateAllWeapons();
            
            transform.Find("Hand").gameObject.SetActive(true);
        }

        private void DeactivateAllWeapons()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        
        private void Update()
        {
            if (Input.GetKey(_controls.drop))
            {
                DropWeapon();
            }
        }

        private void ChangeWeapon(Collider2D col)
        {
            if (Input.GetKey(_controls.attack))
            {
                DeactivateAllWeapons();
                var test = col.transform.name;
                Transform tmp = transform.Find(test);
                tmp.gameObject.SetActive(true);
            }  
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            ChangeWeapon(col);
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            ChangeWeapon(col);
        }

        private void DropWeapon()
        {
            DeactivateAllWeapons();
            transform.Find("Hand").gameObject.SetActive(true);
        }
    }
}