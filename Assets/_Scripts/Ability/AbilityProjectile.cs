using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityProjectile : MonoBehaviour
{
    public int damage;
    public GameObject particleDestroy;
    public float speed;
    public float delayTime;

    private bool canMove;

    public virtual void Init(int damage, float speed, float delayTime)
    {
        this.damage = damage;
        this.speed = speed;
        this.delayTime = delayTime;
        Invoke(nameof(CanMove), delayTime);
    }

    private void CanMove()
    {
        canMove = true;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnterLogic(collision);
    }

    protected virtual void OnTriggerEnterLogic(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Vector3 offset;
            if (transform.position.x - collision.transform.position.x > 0)
                offset = new(-.5f, 0, 0);
            else
                offset = new(.5f, 0, 0);
            if (particleDestroy != null) Destroy(Instantiate(particleDestroy, transform.position + offset, Quaternion.identity), 2);
            Destroy(this.gameObject);
        }
    }

    protected virtual void Update()
    {
        if (canMove)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
