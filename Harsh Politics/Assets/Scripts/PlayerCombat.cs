using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator playerAnim;
    private KeyCode throwball;

    private void Start()
    {
        throwball = FindObjectOfType<PlayerController>().throwBall;
    }

    private void Update()
    {
        //activates animation when pressed Key and Current Weapon Animation is Idle
        if (Input.GetKey(throwball) && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle Weapon"))
        {
            playerAnim.SetTrigger("Slash");
        }
    }
}