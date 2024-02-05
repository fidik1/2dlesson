using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAbility : Ability
{
    public float projectilesCount;
    public float offsetX;
    public Transform spawnPos;

    public override void CreateAbility(PlayerController playerController)
    {
        StartCoroutine(CreateProjectile());
    }

    private IEnumerator CreateProjectile()
    {
        float mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        for (int i = 0; i < projectilesCount; i++)
        {
            AbilityProjectile projectile = Instantiate(abilityPrefab, new Vector3(mousePos + Random.Range(-offsetX, offsetX), spawnPos.position.y), Quaternion.identity);
            projectile.Init(damage, projectileSpeed, delayTime);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
