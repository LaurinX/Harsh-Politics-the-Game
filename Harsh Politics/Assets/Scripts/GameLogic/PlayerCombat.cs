    using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator playerAnim;
    private KeyCode throwball;

    private void Start()
    {
        //Changed PlayerController and created PlayerControls to make it easier to load different prefabs with same controls
        //TODO Make use of PlayerControls and its keycodes the right way. Example in PlaserController.cs
        //throwball = FindObjectOfType<PlayerController>().attack;
        throwball = KeyCode.U;
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