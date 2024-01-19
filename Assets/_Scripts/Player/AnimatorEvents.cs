using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    public PlayerAttack playerAttack;

    private void Attack()
    {
        playerAttack.DealDamage();
    }
}
