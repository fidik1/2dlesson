using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerAnimator animator;

    public int damage;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackDelay = 2f;
    private float attackTime = 0f;

    private void Update()
    {
        if (attackTime >= attackDelay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                attackTime = 0;
            }
        }
        else attackTime += Time.deltaTime;
    }

    private void Attack()
    {
        animator.Attack();
    }

    public void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
