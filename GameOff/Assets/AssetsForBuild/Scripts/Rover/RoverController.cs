using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverController : MonoBehaviour
{
    public bool IsPlayerInCar { get; private set; }

    public bool IsPlayerNearCar { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!IsPlayerInCar)
            {
                IsPlayerNearCar = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!IsPlayerInCar)
            {
                IsPlayerNearCar = false;
            }
        }
    }

    public void GetInTheCar()
    { }

    public void GetOutOfCar()
    { }
}
