using System;
using DefaultNamespace;
using UnityEngine;

namespace GameLogic
{
    public class Throwable : MonoBehaviour
    {
        private Rigidbody2D _body;

        private float speed = 20;
        
        private void Start()
        {
            Throwing(false);
        }

        private void Update()
        {
            Destroy(this);
        }

        public void Throwing(bool direction)
        {
            _body = GetComponent<Rigidbody2D>();
                if (direction)
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