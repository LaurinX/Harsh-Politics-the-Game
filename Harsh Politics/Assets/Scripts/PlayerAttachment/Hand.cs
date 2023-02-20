using System;
using DefaultNamespace.InspectorSettings;
using UnityEngine;

namespace PlayerAttachment
{
    [Serializable]
    public class Hand
    {
        [ReadOnly]
        [SerializeField]
        private int _strength;
    }
}