using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPhysicProjectile : AbilityProjectile
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-4f, 4f), -1) * speed);
    }

    protected override void OnTriggerEnterLogic(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Enemy>())
                collision.GetComponent<Enemy>().TakeDamage(damage);
            if (particleDestroy != null) Destroy(Instantiate(particleDestroy, transform.position, Quaternion.identity), 2);
            Destroy(this.gameObject);
        }
    }

    protected override void Update()
    {
        
    }
}
