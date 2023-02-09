using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed;
    public int bulletDecay;

    private Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
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
        theRB.velocity = new(bulletSpeed * -transform.localScale.x, 0);
    }
    void bulletDestroy()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        bulletDestroy();
    }
}
