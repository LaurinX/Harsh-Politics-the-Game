using DefaultNamespace;
using Entities;
using GameLogic;
using UnityEngine;

namespace PlayerAttachment
{
    public class Hand : MonoBehaviour
    {
        private PlayerControls _controls;
        
        private Transform _currentWeapon;
        
        private float holdTime = 0;
        
        private void Start()
        {
            CreateDefaultWeapon();
            
            _controls = transform.parent.GetComponent<PlayerControls>();
            
            gameObject.AddComponent<Combat>();
        }

        private void Update()
        {
            Counter(Input.GetKey(_controls.interaction));
            
            if (holdTime is > 0f and < 0.5f && _currentWeapon is not null)
            {
                DropWeapon(_currentWeapon.gameObject);
                _currentWeapon = null;
            }
        }

        private void Counter(bool interactionKey)
        {
            if (interactionKey)
            {
                holdTime += 1 * Time.deltaTime;
            }
            else
            {
                holdTime = 0;
            }
        }
        
        private void ChangeWeapon(Transform weapon)
        {
            if (_currentWeapon != null)
            {
                DropWeapon(_currentWeapon.gameObject);
            }
            Destroy(weapon.GetComponent<Rigidbody2D>());
            weapon.GetComponent<Weapon>().SetMaster(true);
            weapon.SetParent(transform, false);
            weapon.localRotation = Quaternion.identity;
            weapon.gameObject.GetComponent<Collider2D>().isTrigger = true;
            weapon.localPosition = Vector3.zero;
            _currentWeapon = weapon;
            weapon.gameObject.AddComponent<Combat>();
            SetDefaultWeapon(false);
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (Input.GetKey(_controls.interaction) &&
                col.gameObject.tag == "Weapon" &&
                holdTime >= 0.5f)
            {
                ChangeWeapon(col.transform);
            }
        }

        private void DropWeapon(GameObject weapon)
        {
            weapon.AddComponent<Rigidbody2D>();
            weapon.GetComponent<Collider2D>().isTrigger = false;
            weapon.GetComponent<Weapon>().SetMaster(false);
            Destroy(weapon.GetComponent<Combat>());
            weapon.AddComponent<Throwable>().GetComponent<Throwable>().Throwing(GetComponentInParent<PlayerBody>().CurrentFaceDirection());
            weapon.transform.parent = null;
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
        }
    }
}