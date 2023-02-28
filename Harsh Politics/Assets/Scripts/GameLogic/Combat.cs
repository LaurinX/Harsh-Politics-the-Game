using Entities;
using UnityEngine;

//attached to hand
namespace GameLogic
{
    public class Combat : MonoBehaviour
    {
        private PlayerControls _controls;
        
        private Transform _enemy;

        private float holdTime = 0;
        
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

            if (holdTime >= 2f)
            {
                SpecialAttack();
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

        }

        private void Defense()
        {
        
        }

    }
}
