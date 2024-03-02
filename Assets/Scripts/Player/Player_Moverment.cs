using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharracterController controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            controller.Jump();

            animator.SetBool("IsJumping", true);
        }

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    animator.SetBool("attack", true);
        //}
        //else
        //{
        //    animator.SetBool("attack", false);
        //}

        if (Input.GetButton("Attack"))
        {
            controller.Attack();
            animator.SetTrigger("Attack");
            animator.SetBool("isAttack", true);
        }

        //if (Input.GetButtonDown("Crouch"))
        //{
        //    crouch = false;
        //}
        //else if (Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
        //}
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        animator.ResetTrigger("Attack");
        animator.SetBool("isAttack", false);
    }

}
