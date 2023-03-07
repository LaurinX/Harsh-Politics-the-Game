using System;
using UnityEngine;

namespace PlayerAttachment
{
    [Serializable]
    public class Armor : GUI
    {
        [SerializeField]
        private int _protectionLevel;
        
        //is equipped and selectable only
    }
}