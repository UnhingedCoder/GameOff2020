using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDController : MonoBehaviour
{
    public Image oxygenBar;
    public Image healthBar;

    private PlayerOxygenController _playerOxygen;
    private PlayerHealthController _playerHealth;

    private void Awake()
    {
        _playerOxygen = FindObjectOfType<PlayerOxygenController>();
        _playerHealth = FindObjectOfType<PlayerHealthController>();
    }

    private void Update()
    {
        oxygenBar.fillAmount = _playerOxygen.CurrentOxygen / _playerOxygen.TotalOxygen;
        healthBar.fillAmount = _playerHealth.CurrentHealth / _playerHealth.TotalHealth;
    }
}
