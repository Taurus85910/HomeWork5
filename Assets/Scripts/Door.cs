using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Door : MonoBehaviour
{

    [SerializeField] private UnityEvent _entry;
    private bool _isRobberInHouse;
    private bool _isRobberWasInHouse;
    private SpriteRenderer _door;
    private AudioSource _audio;


    private void Start()
    {
        _door = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            if (!_isRobberInHouse)
            {
                _door.color = Color.red;
                _isRobberInHouse = true;
                _isRobberWasInHouse = true;
                _entry?.Invoke();
            }
            else
            {
                _door.color = Color.green;
                _isRobberInHouse = false;
            }
        }
    }

    private void Update()
    {
        if (_isRobberInHouse)
            _audio.volume += 0.001f;
        else
            _audio.volume -= 0.01f;
        if (_isRobberWasInHouse && !_isRobberInHouse && _audio.volume == 0)
            _audio.Stop();
    }
}
