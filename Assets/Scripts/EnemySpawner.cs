using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _enemiesCount;

    private Transform[] _spawnPoints;
    private int _currentPointIndex;
    private int _previousPointIndex;
    private float _secondsBetweenEnemySpawn;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];
        _previousPointIndex = -1;
        _currentPointIndex = -1;
        _secondsBetweenEnemySpawn = 2f;

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }

        var _createEnemyObject = StartCoroutine(CreateEnemyObject());
    }

    IEnumerator CreateEnemyObject()
    {
        for(int i = 0;i < _enemiesCount; i++)
        {
            while (_currentPointIndex == _previousPointIndex)
            {
                _currentPointIndex = Random.Range(0, transform.childCount);
            }

            _previousPointIndex = _currentPointIndex;
            Instantiate(_enemy, _spawnPoints[_currentPointIndex]);
            yield return new WaitForSeconds(_secondsBetweenEnemySpawn);
        }
    }
}
