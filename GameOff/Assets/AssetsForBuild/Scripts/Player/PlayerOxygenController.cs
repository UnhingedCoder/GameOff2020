using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerOxygenController : MonoBehaviour
{
    public float TotalOxygen;
    public float CurrentOxygen { get; private set; }

    public float rateOfOxygenReduction;

    [HideInInspector] public UnityEvent e_Jump;

    private void OnEnable()
    {
        CurrentOxygen = TotalOxygen;
    }

    private void Update()
    {
        BreatheOxygen();


    }

    void BreatheOxygen()
    {
        if (CurrentOxygen > 0)
        {
            CurrentOxygen -= Time.deltaTime * rateOfOxygenReduction;
        }
    }

    void RefillOxygen()
    {

    }

    public bool IsOxygenAvailable()
    {
        return CurrentOxygen > 0 ? true : false;
    }
}
