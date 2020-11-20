using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _entry;
    [SerializeField] private Door _door;
    private AudioSource _audio;
    private bool _isAlarmStarted;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
        _isAlarmStarted = false;
    }

    void Update()
    {
        if (!_isAlarmStarted && _door.CheckRobberInHouse())
        {
            _entry?.Invoke();
            _isAlarmStarted = true;
        }
        if (_door.CheckRobberInHouse())
        {           
            _audio.volume += 0.001f;
        }
        else
        {
            _audio.volume -= 0.01f;
        }
        if (!_door.CheckRobberInHouse() && _audio.volume == 0)
            _audio.Stop();
    }
}
