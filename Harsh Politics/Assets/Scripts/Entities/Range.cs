using System;
using DefaultNamespace.InspectorSettings;
using UnityEngine;

namespace Entities
{
    public class Range : Weapon
    {
        [SerializeField]
        private int maxBulletNumber;

        [ReadOnly]
        [SerializeField]
        private int currentBulletNumber;
        
        [SerializeField]
        private int bulletCoolDown;

        private float internalCount;
        
        private void Update()
        {
            CheckIfMasterExists();
            Counter();
        }

        private void Start()
        {
            currentBulletNumber = maxBulletNumber;
        }

        private void Counter()
        {
            internalCount += 1 * Time.deltaTime;
        }

        public override void Attack()
        {
            if (currentBulletNumber > 0 && internalCount >= (float)bulletCoolDown
                && !StrikeMode)
            {
                currentBulletNumber--;
                GameObject bulletClone = Instantiate(Resources.Load("Bullet/Bullet") as GameObject, transform.parent.position, transform.parent.rotation);
                bulletClone.transform.localScale = transform.localScale;
                bulletClone.transform.SetParent(transform);
                internalCount = 0;
            }
        }

        protected override void Animation()
        {
            
        }
    }
}