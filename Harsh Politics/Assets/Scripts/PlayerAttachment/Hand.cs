using DefaultNamespace;
using Entities;
using GameLogic;
using SupportFiles;
using UnityEngine;

namespace PlayerAttachment
{
    public class Hand : MonoBehaviour
    {
        private PlayerControls _controls;
        
        private Transform _currentWeapon;
        
        private float holdTime = 0;

        private FaceDirection _faceDirection;
        
        private void Start()
        {
            //TODO: how to know where the default face direction is? So setting it manually should be removed
            _faceDirection = FaceDirection.Right;
            
            CreateDefaultWeapon();
            
            _controls = GetComponentInParent<PlayerControls>();
            
            gameObject.AddComponent<Combat>();
        }

        private void Update()
        {
            
            HandRotation(Input.GetKey(_controls.left), Input.GetKey(_controls.right));

            Counting(Input.GetKey(_controls.interaction));
            
            if (holdTime is > 0f and < 0.5f && _currentWeapon is not null)
            {
                DropWeapon(_currentWeapon.gameObject);
                _currentWeapon = null;
            }
        }
        
        //Naming is bad, it basically changes the object position, which holds weapons and fist relative to the player face direction
        private void HandRotation(bool  left = false, bool right = false)
        {
            if (left && _faceDirection == FaceDirection.Right)
            {
                transform.localPosition = new Vector3(-transform.localPosition.x, 0, 0);
                transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
                _faceDirection = FaceDirection.Left;
            }
            if (right && _faceDirection == FaceDirection.Left)
            {
                transform.localPosition = new Vector3(-transform.localPosition.x, 0, 0);
                transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
                _faceDirection = FaceDirection.Right;
            }
        }

        private void Counting(bool interactionKey)
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
            weapon.SetParent(transform, false);
            weapon.localRotation = Quaternion.identity;
            weapon.gameObject.GetComponent<Collider2D>().isTrigger = true;
            weapon.localPosition = Vector3.zero;
            _currentWeapon = weapon;
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
            //TODO:expensive can it be refactored?
            weapon.GetComponent<Collider2D>().isTrigger = false;
            weapon.AddComponent<Throwable>().GetComponent<Throwable>().Throwing(_faceDirection);
            weapon.transform.parent = null;
            SetDefaultWeapon(true);
        }

        private void CreateDefaultWeapon()
        {
            //Creates a Fist
            var fist = Instantiate(Resources.Load("Default/Fist") as GameObject, transform);
            //renaming 
            fist.name = "Fist";
        }

        private void SetDefaultWeapon(bool modus)
        {
            transform.GetChild(0).gameObject.SetActive(modus);
        }

        public FaceDirection CurrentFaceDirection()
        {
            return _faceDirection;
        }
    }
}