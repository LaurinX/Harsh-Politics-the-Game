using UnityEngine;

namespace Entities
{
    public class Bullet : MonoBehaviour
    {
        public int bulletSpeed;
        public int bulletDecay;
        private int bulletDamage;

        private Rigidbody2D theRB;
        // Start is called before the first frame update
        void Start()
        {
            bulletDamage = GetComponentInParent<Range>().GetDamageValue();
            theRB = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            bulletDecay--;
            if (bulletDecay == 0)
            {
                bulletDestroy();
            }
            //instead of velocity addforce?
            theRB.velocity = new(bulletSpeed * transform.localScale.x, 0);
            
            // if (Input.GetKey(_controls.attack) && bulletCooldown == 0)
            // {
            //     GameObject bulletClone = (GameObject)Instantiate(Bullet, throwPoint.position, throwPoint.rotation);
            //     bulletClone.transform.localScale = transform.localScale;
            //     bulletCooldown = bulletCooldownBase;
            // }
            
            
        }
        void bulletDestroy()
        {
            Destroy(gameObject);
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            bulletDestroy();
        }

        public int BulletDamage()
        { 
            return bulletDamage;
        }
    }
    
}