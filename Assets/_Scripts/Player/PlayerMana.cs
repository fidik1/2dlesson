using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMana : MonoBehaviour
{
    public float maxMana;
    public float mana;

    public event Action ManaChanged;

    public bool CanSpendMana(float manaToSpend)
    {
        return mana >= manaToSpend;
    }

    public void SpendMana(float manaToSpend)
    {
        if (mana >= manaToSpend)
        {
            mana -= manaToSpend;
            ManaChanged?.Invoke();
        }
    }
}
