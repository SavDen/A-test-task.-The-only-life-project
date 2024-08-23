using UnityEngine;
using UnityEngine.UI;

public class CointerKill: MonoBehaviour
{
    public static float CountKill;

    [SerializeField] private Spawner _maxCount;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private Text _countKill ,_needKill;

    private void Awake()
    {
        CountKill = 0;
    }

    private void FixedUpdate()
    {
        UpdateUI();

        if(CountKill == _maxCount.GetMaxCount)
        {
            _gameOverUI.SetActive(true);
        }
    }

    private void UpdateUI()
    {
        _countKill.text = CountKill.ToString();
        _needKill.text = _maxCount.GetMaxCount.ToString();

    }
}
