using System;
using DefaultNamespace.InspectorSettings;
using UnityEngine;

namespace PlayerAttachment
{
    [Serializable]
    public class Armor
    {
        [ReadOnly]
        [SerializeField]
        private int _protectionLevel;
        
        //is equipped and selectable only
    }
}