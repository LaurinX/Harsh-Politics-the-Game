using UnityEngine;

public class PlayerControls : MonoBehaviour

{
    public float moveSpeed;
    public float jumpForce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode attack;
    
    public KeyCode interaction;

    public LayerMask whatIsGround;
}
