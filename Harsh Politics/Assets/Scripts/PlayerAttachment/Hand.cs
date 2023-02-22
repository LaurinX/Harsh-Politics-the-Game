using System;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

namespace PlayerAttachment
{
    public class Hand : MonoBehaviour
    {
        private PlayerControls _controls;

        private bool rightKey;

        private bool leftKey;

        private void Start()
        {
            _controls = transform.parent.parent.GetComponent<PlayerControls>();

            DeactivateAllWeapons();
            
            transform.GetComponentInChildren<Transform>().Find("Hand").gameObject.SetActive(true);
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
            if (Input.GetKey(_controls.right) &&
                !rightKey)
            {
                transform.RotateAround(transform.parent.position, Vector3.down, 180f);
                rightKey = true;
                leftKey = false;
            }
            if(Input.GetKey(_controls.left) &&
               !leftKey)
            {
                transform.RotateAround(transform.parent.position, Vector3.up, 180f);
                rightKey = false;
                leftKey = true;
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
                col.transform.parent.gameObject.GetComponent<WeaponGenerator>().PickedUpWeapon(test);
            }  
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            try
            {
                if (col.transform.parent.name == "WeaponGenerator")
                {
                    ChangeWeapon(col);
                }
            }
            catch (Exception e)
            {
            }
        }

        private void DropWeapon()
        {
            DeactivateAllWeapons();
            transform.GetComponentInChildren<Transform>().Find("Hand").gameObject.SetActive(true);
        }
    }
}