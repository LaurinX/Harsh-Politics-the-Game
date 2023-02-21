using System;
using UnityEngine;

namespace PlayerAttachment
{
    public enum Weapon { Dagger, Knife, Axe, Hand, Shield }
    [Serializable]
    public class Hand
    {
        //holding weapon objects as prefab list
        [SerializeField]
        private GameObject _equipment;

        private void SelectWeapon()
        {
            
        }

    }
}