using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;
    public GameObject Bullet;
    public Transform throwPoint;
    public int bulletCooldownBase;
    public int bulletCooldown = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletCooldown> 0)
        {
            bulletCooldown--;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
       
        if (Input.GetKey(left)) 
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        } else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKey(jump)&& isGrounded )
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetKey(throwBall)&& bulletCooldown == 0)
        {
            GameObject bulletClone =  (GameObject)Instantiate(Bullet, throwPoint.position, throwPoint.rotation);
            bulletClone.transform.localScale = transform.localScale;
            bulletCooldown = bulletCooldownBase;
        }
    }
}
