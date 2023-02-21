using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace
{
    public class WeaponGenerator : MonoBehaviour
    {

        private int currentWeapon;
        
        private void Start()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            StartCoroutine(GenerateNewWeapon(5));
        }

        private int SelectNewWeapon()
        {
            currentWeapon = new Random().Next(0, transform.childCount - 1);
            return currentWeapon;
        }
        
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
            transform.GetChild(currentWeapon).gameObject.SetActive(false);
            //Reset Position of Child relative to Parent
            // TODO : change location randomly relative to parent
            transform.GetChild(currentWeapon).localPosition = Vector3.zero;
        }
    }
}