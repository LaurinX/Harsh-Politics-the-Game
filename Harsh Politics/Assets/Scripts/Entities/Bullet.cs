using System.Numerics;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float bulletDecay = 5f;

        private int bulletDamage;

        private Rigidbody2D bulletBody;

        private bool bulletDirection = false;
        
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

            if (bulletDirection)
            {
                bulletBody.AddForce(Vector2.left,ForceMode2D.Force);
            }
            else
            {
                bulletBody.AddForce(Vector2.right,ForceMode2D.Force);
            }
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

        public void SetBulletDamage(int damage)
        {
            bulletDamage = damage;
        }

        public void SetBulletDirection(bool direction)
        {
            bulletDirection = direction;
        }
    }
    
}