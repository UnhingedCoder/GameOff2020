using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : Unit
{
    private PlayerOxygenController _playerOxygen;

    public float rateOfHealthReduction;

    private void Awake()
    {
        _playerOxygen = this.GetComponent<PlayerOxygenController>();
    }
    private void OnEnable()
    {
        CurrentHealth = TotalHealth;    
    }

    private void Update()
    {
        ReduceHealthOnOxygenOver();
    }

    public override void TakeDamage(int dmgAmt)
    {
        base.TakeDamage(dmgAmt);
    }

    public override void Heal(int healAmt)
    {
        base.Heal(healAmt);
    }

    void ReduceHealthOnOxygenOver()
    {
        if (!_playerOxygen.IsOxygenAvailable() && CurrentHealth > 0)
        {
            CurrentHealth -= Time.deltaTime * rateOfHealthReduction;
        }
    }
}
