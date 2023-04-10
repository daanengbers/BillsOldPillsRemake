using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public Joystick joystick;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        //walk on pc
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //walk on mobile v1
        if(joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }

        //walk on mobile v2
        //    horizontalMove = joystick.Horizontal * runSpeed;

        //jump on pc
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        //move char
        controller.Move(horizontalMove * Time.deltaTime, crouch, jump);
        jump = false;
        animator.SetBool("Jump", false);

        if (horizontalMove != 0)
        {
            if (jump == false && crouch == false)
            {
                animator.SetBool("Running", true);
            }
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

    public void ButtonJump()
    {
        jump = true;
        animator.SetBool("Jump", true);
    }
}
