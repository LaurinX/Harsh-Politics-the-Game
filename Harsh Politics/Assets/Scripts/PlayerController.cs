using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls _controls;
    
    private Rigidbody2D theRB;


    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public CharacterDb character;
    public string playerPrefKeyString;
    
    
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public bool isGrounded;

    private GameObject _audio;

    private bool audioPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        _controls = GetComponentInParent<PlayerControls>();
        
        theRB = GetComponentInParent<Rigidbody2D>();

        _animator = GetComponent<Animator>();
        
        _audio = Instantiate(Resources.Load<GameObject>("PlayerAudio/PlayerAudio"), transform);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = character.character[PlayerPrefs.GetInt(playerPrefKeyString)].characterSprite;
        Debug.Log(PlayerPrefs.GetInt(playerPrefKeyString));
        
        _spriteRenderer.sprite = character.character[PlayerPrefs.GetInt(playerPrefKeyString)].characterSprite;
        Debug.Log(PlayerPrefs.GetInt(playerPrefKeyString));
    }

    // Update is called once per frame
    void Update()
    {
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
            _audio.GetComponent<Audio>().AudioStop(1);
            audioPlayed = !audioPlayed;
        }

        if (Input.GetKey(_controls.jump)&& isGrounded )
        {
            _animator.SetTrigger("JumpButtonClicked");
            theRB.velocity = new Vector2(theRB.velocity.x, _controls.jumpForce);
            _audio.GetComponent<Audio>().AudioPlay(0);
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        } else if ( theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (theRB.velocity.x != 0 && !audioPlayed)
        {
            _audio.GetComponent<Audio>().AudioPlay(1);
            audioPlayed = !audioPlayed;
        }
        

        _animator.SetBool("isGrounded",isGrounded);
      
    }
}
