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
<<<<<<< HEAD
        if (!_isAlarmStarted && _door.CheckAlarm())
=======
        if (!_isAlarmStarted && _door.CheckRobberInHouse())
>>>>>>> 624e08ac9e4d793d30c2215fc200f58273c8bb20
        {
            _entry?.Invoke();
            _isAlarmStarted = true;
        }
<<<<<<< HEAD
        if (_door.CheckAlarm())
=======
        if (_door.CheckRobberInHouse())
>>>>>>> 624e08ac9e4d793d30c2215fc200f58273c8bb20
        {           
            _audio.volume += 0.001f;
        }
        else
        {
            _audio.volume -= 0.01f;
        }
<<<<<<< HEAD
        if (!_door.CheckAlarm() && _audio.volume == 0)
=======
        if (!_door.CheckRobberInHouse() && _audio.volume == 0)
>>>>>>> 624e08ac9e4d793d30c2215fc200f58273c8bb20
            _audio.Stop();
    }
}
