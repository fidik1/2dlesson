using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public AbilityProjectile abilityPrefab;
    public int damage = 1;
    public float cooldown = 1;
    public float projectileSpeed = 1;
    public float delayTime;

    private bool canUse = true;

    public void Use(PlayerController playerController)
    {
        if (canUse)
        {
            CreateAbility(playerController);
            StartCoroutine(Cooldown());
        }
    }

    public virtual void CreateAbility(PlayerController playerController)
    {
        float rotate = 0;
        if (playerController.m_FacingRight)
        {
            rotate = abilityPrefab.transform.eulerAngles.y;
        }
        else
        {
            rotate = abilityPrefab.transform.eulerAngles.y - 180;
        }
        AbilityProjectile projectile = Instantiate(abilityPrefab, transform.position, Quaternion.Euler(0, rotate, 0));
        projectile.Init(damage, projectileSpeed, delayTime);
    }

    private IEnumerator Cooldown()
    {
        canUse = false;
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }
}
