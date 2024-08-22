using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class EnemySpawner : Spawner
{
    public override IEnumerator Spawn(float delay)
    {
        var spawnCount = 0;

        while (spawnCount < _maxCountSpawn)
        {
            yield return new WaitForSeconds(delay);
            var enemy = LeanPool.Spawn(_prefab[Random.Range(0, _prefab.Count)], _points[Random.Range(0, _points.Count)].position, Quaternion.identity);
            enemy.GetComponent<Enemy>().DownloadData();
            spawnCount++;
        }
    }
}
