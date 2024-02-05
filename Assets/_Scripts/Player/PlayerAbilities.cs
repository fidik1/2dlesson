using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Ability firstAbility;
    [SerializeField] private Ability secondAbility;
    [SerializeField] private Ability dashAbility;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseAbility(firstAbility);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseAbility(secondAbility);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            UseAbility(dashAbility);
        }
    }

    private void UseAbility(Ability ability)
    {
        ability.Use(playerController);
    }
}
