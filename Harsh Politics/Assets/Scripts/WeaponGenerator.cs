using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

public enum WeaponList
{
    Dagger, Sword, Shield
}
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField]
        [Range(5,20)]
        private int generateNewInSec;

        private Transform _currentWeapon;
        
        private void Start()
        {
            StartCoroutine(GenerateNewWeapon(generateNewInSec));
        }

        //this method is temporary and shall be substituted 
        private string RandomizeThroughTheList()
        {
            var ranNum = new Random().Next(0, Enum.GetNames(typeof(WeaponList)).Length);
            return Enum.GetName(typeof(WeaponList), ranNum);
        }
        
        // TODO: need Refactoring
        private IEnumerator GenerateNewWeapon(int seconds)
        {
            while (true)
            {
                CreateWeapon();
                //waiting for x-amount of seconds
                yield return new WaitForSeconds(seconds);
            }
        }

        private void CreateWeapon()
        {
            string name = "Weapon/" + RandomizeThroughTheList();
            var weapon = Instantiate(Resources.Load(name) as GameObject, transform);
            weapon.GetComponent<Collider2D>().isTrigger = false;
            weapon.AddComponent<Rigidbody2D>();
            _currentWeapon = weapon.transform;
        }

    }