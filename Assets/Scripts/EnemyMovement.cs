using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    private Vector3 _centerPoint;

    private void Start()
    {
        _centerPoint = new Vector3(0,0,0);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _centerPoint, _enemySpeed * Time.deltaTime);

        if (transform.position == _centerPoint)
            Destroy(gameObject);
    }
}
