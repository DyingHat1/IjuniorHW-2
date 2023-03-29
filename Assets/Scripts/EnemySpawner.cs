using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemy;
    [SerializeField] private int _enemiesCount;

    private Transform[] _spawnPoints;
    private int _currentPointIndex = -1;
    private int _previousPointIndex = -1;
    private float _secondsBetweenEnemySpawn = 2f;
    private WaitForSeconds _waitForSeconds;


    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];
        _waitForSeconds = new WaitForSeconds(_secondsBetweenEnemySpawn);

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }

        StartCoroutine(CreateEnemyObject());
    }

    private IEnumerator CreateEnemyObject()
    {
        for(int i = 0;i < _enemiesCount; i++)
        {
            while (_currentPointIndex == _previousPointIndex)
            {
                _currentPointIndex = Random.Range(0, transform.childCount);
            }

            _previousPointIndex = _currentPointIndex;
            Instantiate(_enemy, _spawnPoints[_currentPointIndex]);
            yield return _waitForSeconds;
        }
    }
}
