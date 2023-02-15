using System;
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
        if (Input.GetKey(throwball))
        {
            playerAnim.SetTrigger("Slash");
        }
    }
}