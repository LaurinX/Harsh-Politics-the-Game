using GameLogic;
using SupportFiles;
using UnityEngine;

namespace Entities
{
    public class SpecialAbility : MonoBehaviour
    {
        private bool isGrounded;
        
        private FaceDirection _faceDirection;

        private float bulletDecay = 2f;

        private Rigidbody2D bulletBody;

        private Transform parent;

        private void Start()
        {
            bulletBody = GetComponent<Rigidbody2D>();
            
        }

        private void Update()
        {
            if (isGrounded)
            {
                bulletDecay -= 1 * Time.deltaTime;
                if (bulletDecay <= 0f)
                {
                    bulletDestroy();
                }

                if (_faceDirection == FaceDirection.Left)
                {
                    bulletBody.AddForce(Vector2.left*10,ForceMode2D.Impulse);
                }
                else
                {
                    bulletBody.AddForce(Vector2.right*10,ForceMode2D.Impulse);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //layer 3 is ground
            if (collision.gameObject.layer == 3)
            {
                isGrounded = true;
                transform.GetComponent<Rigidbody2D>().gravityScale = 0;
                transform.GetComponent<Collider2D>().isTrigger = true;
            }
        }

        void bulletDestroy()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            parent.gameObject.SetActive(true);
            parent.GetComponentInChildren<Combat>().SpecialAttackDestroyed();
        }

        public void SetOrigin(Transform transform)
        {
            parent = transform;
        }
        
        public void CurrentFaceDirection(FaceDirection direction)
        {
            _faceDirection = direction;
        }
    }
}