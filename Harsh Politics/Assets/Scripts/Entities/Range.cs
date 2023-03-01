using DefaultNamespace.InspectorSettings;
using PlayerAttachment;
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
            if (currentBulletNumber > 0 && internalCount >= (float)GetAttackSpeed()
                && !StrikeMode)
            {
                currentBulletNumber--;
                //schlechtes naming das ist eine KUGEL
                var weapon = Instantiate(Resources.Load("Bullet/Bullet") as GameObject, transform);

                weapon.GetComponent<Collider2D>().isTrigger = false;
                weapon.GetComponent<Bullet>().SetBulletDamage(GetDamageValue());
                weapon.GetComponent<Bullet>().CurrentFaceDirection(GetComponentInParent<Hand>().CurrentFaceDirection());

                weapon.transform.parent = null;
                
                internalCount = 0;
            }
        }

        protected override void Animation()
        {
            
        }
    }
}