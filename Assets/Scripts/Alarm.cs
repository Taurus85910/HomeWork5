using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _onSignal;
    [SerializeField] private Door _door;
    private AudioSource _audio;
    private bool _isAlarmStarted;
    private bool _isRobbeInHouse;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
        _isAlarmStarted = false;

    }

    private void Update()
    {
        if (!_isAlarmStarted && _isRobbeInHouse)
        {
            _isAlarmStarted = true;
            StartCoroutine(OnSound());
        }

        if (_isAlarmStarted && !_isRobbeInHouse)
            StartCoroutine(OffSound());
    }

    private IEnumerator OnSound()
    {
        while (true)
        {
            _audio.volume += 0.001f;
            yield return null;
        }
    }

    private IEnumerator OffSound()
    {
        while (true)
        {
            _audio.volume -= 0.001f;
            if (_audio.volume == 0)
                _audio.Stop();
            yield return null;
        }
    }

    public void ChangeRobberPosition()
    {
        _isRobbeInHouse = !_isRobbeInHouse;
    }

}
