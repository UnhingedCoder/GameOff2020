using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float TotalHealth;
    public float CurrentHealth;

    public virtual void TakeDamage(int dmgAmt)
    {
        if (CurrentHealth <= 0)
            return;

        float modifiedHealth = CurrentHealth - dmgAmt;

        CurrentHealth = modifiedHealth <= 0 ? 0 : modifiedHealth;
    }

    public virtual void Heal(int healAmt)
    {
        if (CurrentHealth >= TotalHealth)
            return;

        float modifiedHealth = CurrentHealth + healAmt;

        CurrentHealth = modifiedHealth > TotalHealth ? TotalHealth : modifiedHealth;
    }

    public bool IsAlive()
    {
        return CurrentHealth > 0 ? true : false;
    }
}
