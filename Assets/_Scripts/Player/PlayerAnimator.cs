using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public PlayerController controller;

    private void Start()
    {
        controller.Jump += Jump;
        controller.Land += OnLand;
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Run(bool running)
    {
        animator.SetBool("IsRunning", running);
    }

    public void Grounded(bool grounded)
    {
        animator.SetBool("IsGrounded", grounded);
    }

    private void Jump()
    {
        animator.SetBool("IsGrounded", false);
        animator.SetTrigger("Jump");
    }

    private void OnLand()
    {
        animator.SetBool("IsGrounded", true);
    }
}
