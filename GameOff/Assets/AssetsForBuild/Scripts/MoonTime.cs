using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonTime : MonoBehaviour
{
    public static MoonTime Instance { get; set; }

    public int CurrentDay { get; private set; }

    public float CurrentTime { get; private set; }

    [SerializeField] private float totalTimeInADay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        CurrentTime += Time.deltaTime;

        if (CurrentTime >= totalTimeInADay)
        {
            CurrentDay++;
            CurrentTime = 0;
        }
    }
}
