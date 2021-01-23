using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPath : MonoBehaviour
{
    [SerializeField] private Transform _way;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private Transform _transform;

    private void Start()
    {
        _points = new Transform[_way.childCount];
        _transform = GetComponent<Transform>();
;        for (int i = 0; i < _way.childCount; i++)
        {
            _points[i] = _way.GetChild(i);
        }
    }

    private void Update()
    {
        if (_currentPoint != -1)
        {
            Transform target = _points[_currentPoint];
            Vector3 position = target.position;
            float directionX = position.x - transform.position.x;
            _transform.rotation = directionX <= 0f ? new Quaternion(0, 180, 0, 0) : new Quaternion(0, 0, 0, 120);
            _transform.position = Vector3.MoveTowards(_transform.position, position, _speed * Time.deltaTime);
            if (transform.position == target.position)
                _currentPoint++;
            if (_currentPoint == _points.Length)
                _currentPoint = -1;
        }
    }
}
