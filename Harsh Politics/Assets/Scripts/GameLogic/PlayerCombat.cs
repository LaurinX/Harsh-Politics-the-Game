    using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator playerAnim;
    private PlayerControls _controls;


    private void Start()
    {
        _controls = GetComponent<PlayerControls>();
    }

    private void Update()
    {
        if (Input.GetKey(_controls.attack) )
            //&& playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle Weapon"))
        {
            playerAnim.SetTrigger("Slash");
        }
    }
}