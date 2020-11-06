using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoWay : MonoBehaviour
{
    [SerializeField] private Transform _way;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private void Start()
    {
        _points = new Transform[_way.childCount];
        for (int i = 0; i < _way.childCount; i++)
        {
            _points[i] = _way.GetChild(i);
        }
    }
    private void Update()
    {        
        Transform target = _points[_currentPoint];
        float directionX = target.position.x - transform.position.x;
        if (directionX <= 0f)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 120);
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        if(transform.position == target.position)        
            _currentPoint++;
        //if (_currentPoint == _way.childCount)
        //    _currentPoint = 0;
    }
}
