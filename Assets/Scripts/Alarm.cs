using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _onSignal;
    [SerializeField] private Door _door;
    [SerializeField] private float _swiftness;
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
            _audio.volume = Mathf.MoveTowards(_audio.volume,1, _swiftness/10 * Time.deltaTime); 
            yield return null;
        }
    }

    private IEnumerator OffSound()
    {
        while (true)
        {
           
            _audio.volume = Mathf.MoveTowards(_audio.volume, 0, _swiftness / 10 * Time.deltaTime);
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
