using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField]
        [Range(5,20)]
        private int generateNewInSec;

        private int _currentWeapon;
        
        private void Start()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            StartCoroutine(GenerateNewWeapon(generateNewInSec));
        }

        public void PickedUpWeapon(string name)
        {
            transform.Find(name).gameObject.SetActive(false);
        }

        private int SelectNewWeapon()
        {
            _currentWeapon = new Random().Next(0, transform.childCount - 1);
            return _currentWeapon;
        }
        // TODO: need Refactoring
        private IEnumerator GenerateNewWeapon(int seconds)
        {
            while (true)
            {
                DestroyWeapon();
                CreateWeapon();
                //waiting for x-amount of seconds
                yield return new WaitForSeconds(seconds);
            }
        }

        private void CreateWeapon()
        {
            //Activates new weapon
            transform.GetChild(SelectNewWeapon()).gameObject.SetActive(true);
        }

        private void DestroyWeapon()
        {
            //Deactivates current weapon
            transform.GetChild(_currentWeapon).gameObject.SetActive(false);
            //Reset Position of Child relative to Parent
            // TODO : change location randomly relative to parent
            transform.GetChild(_currentWeapon).localPosition = Vector3.zero;
        }

    }