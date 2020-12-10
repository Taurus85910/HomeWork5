using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _passingDoor;
    private SpriteRenderer _door;
    private bool _isRobbeInHouse;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            _passingDoor?.Invoke();          
        }
    }
}
