using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Door : MonoBehaviour
{

    [SerializeField] private UnityEvent _entry;
    private bool isRobberInHouse;
    private bool isRobberWasInHouse;
    private SpriteRenderer door;
    private AudioSource _audio;


    private void Start()
    {
        door = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            if (!isRobberInHouse)
            {
                door.color = Color.red;
                isRobberInHouse = true;
                isRobberWasInHouse = true;
                _entry?.Invoke();
            }
            else
            {
                door.color = Color.green;
                isRobberInHouse = false;
            }
        }
    }
    private void Update()
    {
        if (isRobberInHouse)
            _audio.volume += 0.001f;
        else
            _audio.volume -= 0.01f;
        if (isRobberWasInHouse && !isRobberInHouse && _audio.volume == 0)
            _audio.Stop();
    }
}
