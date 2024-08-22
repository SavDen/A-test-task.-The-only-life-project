using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class ViewPlayer
{
    [SerializeField] private Slider health;
    [SerializeField] private GameObject _gameOverLose;

    public void StartUpdateUI(float maxHealth)
    {
        health.maxValue = maxHealth;
        health.value = maxHealth;
    }
    public void UpdateUI(float actualHP)
    {
        health.value = actualHP;
    }

    public void ShowGameOver()
    {
        _gameOverLose.SetActive(true);
    }
    
}
