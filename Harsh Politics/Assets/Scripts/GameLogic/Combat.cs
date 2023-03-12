using DefaultNamespace;
using Entities;
using PlayerAttachment;
using Unity.VisualScripting;
using UnityEngine;

//attached to hand
namespace GameLogic
{
    public class Combat : MonoBehaviour
    {
        private PlayerControls _controls;
        
        private Transform _enemy;

        private float holdTime = 0;

        private bool _specialAttackCalled = false;

        private GameObject _currentSpecialAttack;
        
        private void Start()
        {
            _controls = transform.GetComponentInParent<PlayerControls>();
        }

        private void Update()
        {
            
            Counter(Input.GetKey(_controls.attack));
            
            if (holdTime is > 0f and < 0.2f)
            {
                gameObject.GetComponentInChildren<Weapon>().Attack();
            }

            if (holdTime >= 2f && !_specialAttackCalled)
            {
                SpecialAttack();
            }

            if (_currentSpecialAttack is null)
            {
                _specialAttackCalled = false;
            }

            //don't remember why it's here
            if (transform.parent is null)
            {
                Destroy(this);
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
        
        private void SpecialAttack()
        {
            var parent = GetComponentInParent<PlayerBody>().transform;
            var pathString = "SpecialAttacks/";
            pathString += parent.GetComponentInChildren<PlayerController>().gameObject.GetComponent<SpriteRenderer>().sprite.name;
            pathString += "Special";
            _currentSpecialAttack = Instantiate(Resources.Load(pathString) as GameObject, transform);
            _specialAttackCalled = true;
            _currentSpecialAttack.transform.AddComponent<SpecialAbility>();
            _currentSpecialAttack.GetComponent<SpecialAbility>().CurrentFaceDirection(GetComponentInParent<Hand>().CurrentFaceDirection());
            _currentSpecialAttack.GetComponent<SpecialAbility>().SetOrigin(parent);
            parent.gameObject.SetActive(false);
            _currentSpecialAttack.transform.parent = null;
        }

        //optional
        private void Defense()
        {
        
        }

        public void SpecialAttackDestroyed()
        {
            _specialAttackCalled = false;
        }

    }
}
