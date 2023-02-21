using System;
using DefaultNamespace.InspectorSettings;
using UnityEngine;

namespace PlayerAttachment
{
    [Serializable]
    public class Hand
    {
        //holding weapon objects as prefab list
        
        [ReadOnly]
        [SerializeField]
        private int _strength;
        
        public GameObject _equipment;
        
        public Hand()
        {
        }

        //type of equipment, selectable field (gameobject)
    }
}