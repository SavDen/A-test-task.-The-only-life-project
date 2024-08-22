using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _timerUI;
    [SerializeField] private List<Spawner> _spawners;

    private void Awake()
    {
        foreach (var spwner in _spawners)
            spwner.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        var count = _timerUI.Count - 1;

        while(true)
        {
            yield return new WaitForSeconds(1);
            _timerUI[count].SetActive(false);
            count--;

            if (count < 0) break;

            _timerUI[count].SetActive(true);

        }

        foreach (var spwner in _spawners)
            spwner.enabled = true;

        gameObject.SetActive(false);
    }
}
