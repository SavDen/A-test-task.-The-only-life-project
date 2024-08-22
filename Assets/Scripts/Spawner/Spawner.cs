using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _prefab;
    [SerializeField] protected List<Transform> _points;
    [SerializeField] protected int _maxCountSpawn;
    [SerializeField] protected float _delay;

    public int GetMaxCount => _maxCountSpawn;

    private void Start()
    {
        StartCoroutine(Spawn(_delay));

    }

    public virtual IEnumerator Spawn(float delay)
    {
        var spawnCount = 0;

        while(spawnCount < _maxCountSpawn)
        {
            yield return new WaitForSeconds(delay);
            LeanPool.Spawn(_prefab[Random.Range(0, _prefab.Count)], _points[Random.Range(0, _points.Count)]);
            spawnCount++;
        }
    }
}
