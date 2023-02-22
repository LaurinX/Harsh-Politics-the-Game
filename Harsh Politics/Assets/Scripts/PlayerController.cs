using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls _controls;
    
    private Rigidbody2D theRB;

    
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public bool isGrounded;
    // Bullet stuff should not be in PlayerController.cs
    //TODO Create own Script for Bullet Stuff
    public GameObject Bullet;
    public Transform throwPoint;
    public int bulletCooldownBase;
    public int bulletCooldown = 0;

    
   
    // Start is called before the first frame update
    void Start()
    {
        _controls = GetComponentInParent<PlayerControls>();
        
        theRB = GetComponentInParent<Rigidbody2D>();

        _animator = GetComponent<Animator>();
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletCooldown > 0)
        {
            bulletCooldown--;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, _controls.whatIsGround);
       
        if (Input.GetKey(_controls.left)) 
        {
            theRB.velocity = new Vector2(-_controls.moveSpeed, theRB.velocity.y);
            _spriteRenderer.flipX = true;
        }else if (Input.GetKey(_controls.right))
        {
            theRB.velocity = new Vector2(_controls.moveSpeed, theRB.velocity.y);
            _spriteRenderer.flipX = false;
        } else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKey(_controls.jump)&& isGrounded )
        {
            _animator.SetTrigger("JumpButtonClicked");
            theRB.velocity = new Vector2(theRB.velocity.x, _controls.jumpForce);
        }

        if (Input.GetKey(_controls.attack) && bulletCooldown == 0)
        {
            GameObject bulletClone = (GameObject)Instantiate(Bullet, throwPoint.position, throwPoint.rotation);
            bulletClone.transform.localScale = transform.localScale;
            bulletCooldown = bulletCooldownBase;
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        } else if ( theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        _animator.SetBool("isGrounded",isGrounded);
      
    }
}
