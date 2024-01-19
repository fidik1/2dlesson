using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;

    public int maxHealth = 100;
    public float knockbackForce;

    public Transform target;

    int currentHealth;
    private Vector3 scale;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("GetDamage");
        Knockback();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        scale = transform.localScale;
    }

    private void Update()
    {
        if (transform.position.x < target.position.x)
        {
            transform.localScale = scale;
        }
        else
        {
            transform.localScale = new(-scale.x, scale.y, scale.z);
        }
        if (Vector2.Distance(transform.position, target.position) >= 1.1f)
            transform.position = new(Mathf.Lerp(transform.position.x, target.position.x, Time.deltaTime), transform.position.y);
        print(Vector2.Distance(transform.position, target.position));
    }

    private void Knockback()
    {
        Vector2 vector;
        if (transform.position.x < target.position.x)
        {
            vector = -transform.right;
        }
        else
        {
            vector = transform.right;
        }
        rb.AddForce(vector * knockbackForce, ForceMode2D.Impulse);
    }

    private void Die()
    {
        animator.SetBool("Death", true);
    }
}
