using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    public float dashForce = 50f;
    public float dashDuration = 0.5f;
    private bool isDashing = false;

    private PlayerController playerController;

    public override void CreateAbility(PlayerController playerController)
    {
        this.playerController = playerController;
        if (!isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;

        Rigidbody2D playerRigidbody = playerController.GetComponent<Rigidbody2D>();
        Vector2 direction = playerController.m_FacingRight ? transform.right : -transform.right;
        playerRigidbody.AddForce(direction * dashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);

        isDashing = false;
    }
}
