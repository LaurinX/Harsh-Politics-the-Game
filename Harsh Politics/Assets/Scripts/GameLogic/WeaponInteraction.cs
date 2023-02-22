using System;
using UnityEngine;

namespace DefaultNamespace.GameLogic
{
    public class WeaponInteraction : MonoBehaviour
    {
        public bool value = false;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (Input.GetKey(KeyCode.F) && !value)
            {
                PickmeUp(col);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (Input.GetKey(KeyCode.F) && !value)
            {
                PickmeUp(other);
            }
        }
        
        private void PickmeUp(Collision2D collision)
        {
            Instantiate(transform.GetChild(0).transform, collision.transform, false);
            value = true;
            //Attach the weapon to me right now!
        }
    }
}