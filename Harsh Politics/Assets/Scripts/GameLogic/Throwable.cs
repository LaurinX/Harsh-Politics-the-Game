using SupportFiles;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Throwable : MonoBehaviour
    {
        private Rigidbody2D _body;

        private float speed = 40;

        private void Start()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Destroy(this);
        }

        public void Throwing(FaceDirection direction)
        {
                if (direction == FaceDirection.Left)
                {
                    _body.velocity = new(- speed * transform.localScale.x, 0);
                }
                else
                {
                    _body.velocity = new Vector2(speed * transform.localScale.x, 0);
                }
                _body.angularVelocity = 20;
        }
    }
}