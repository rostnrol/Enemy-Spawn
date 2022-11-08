using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCall : MonoBehaviour
{
    [SerializeField] private Transform _spawnMap;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _sceneDuration;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnMap.childCount];

        for (int i = 0; i < _spawnMap.childCount; i++)
        {
            _spawnPoints[i] = _spawnMap.GetChild(i);
        }

        var enemySpawn = StartCoroutine(SpawnEnemies(2));
    }

    private IEnumerator SpawnEnemies(float duration)
    {
        var spawnWait = new WaitForSeconds(duration);

        while (_sceneDuration > 0)
        {
            int respawnPointNumber = Random.Range(0, _spawnMap.childCount);
            Instantiate(_enemy, _spawnPoints[respawnPointNumber].position, _spawnPoints[respawnPointNumber].rotation);
            _sceneDuration -= 1;

            yield return spawnWait;    
        }
    }
}
