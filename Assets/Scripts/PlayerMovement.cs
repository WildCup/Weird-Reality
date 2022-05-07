using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController2D controller2D;
    Animator animator;
    public float speed = 1f;
    float horizontalInput = 0f;
    bool jumping = false;
    bool startedJump = false;

    private void Awake()
    {
        controller2D = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        speed *= PlayerStats.instance.speed * 0.05f + 1f;
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        if (Input.GetButtonDown("Jump"))
        {
            startedJump = true;
            animator.SetBool("Jumping", true);
        }
        if (Input.GetButton("Jump"))
            jumping = true;
        //sound
        if (Mathf.Abs(horizontalInput) > 0)
            AudioManager.instance.PlayRandom();
    }
    private void FixedUpdate()
    {
        //move our player
        controller2D.Move(horizontalInput * Time.fixedDeltaTime, jumping, startedJump);
        jumping = false;
        startedJump = false;
    }
    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
        AudioManager.instance.Play("Landing");
    }
}
