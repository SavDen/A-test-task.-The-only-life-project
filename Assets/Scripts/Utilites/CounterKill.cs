using UnityEngine;
using System;

public class CointerKill: MonoBehaviour
{
    public static float CountKill;
    public static event Action GameOver;

    [SerializeField] private Spawner _maxCount;
    [SerializeField] private GameObject _gameOverUI;

    private void Awake()
    {
        CountKill = 0;
    }

    private void FixedUpdate()
    {
        if(CountKill == _maxCount.GetMaxCount)
        {
            _gameOverUI.SetActive(true);
            GameOver?.Invoke();
        }
    }
}
