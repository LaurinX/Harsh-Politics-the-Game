using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public float bulletDecay;
        public int bulletDamage;

        public Rigidbody2D bulletBody;
        
        void Start()
        {
            bulletBody = GetComponent<Rigidbody2D>();

        }

        void Update()
        {
            bulletDecay -= 1 * Time.deltaTime;
            if (bulletDecay <= 0f)
            {
                bulletDestroy();
            }
            
            bulletBody.AddForce(Vector2.right,ForceMode2D.Force);
        }
        void bulletDestroy()
        {
            Destroy(gameObject);
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            bulletDestroy();
        }

        public int BulletDamage()
        { 
            return bulletDamage;
        }

        public void SetBulletDamage(int damage)
        {
            bulletDamage = damage;
        }
    }
    
}