using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{

    private SpriteRenderer _door;
    private bool _isRobberInHouse;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            if (!_isRobberInHouse)          
                _isRobberInHouse = true;                        
            else            
                _isRobberInHouse = false;           
        }
    }
    public bool CheckRobberInHouse() => _isRobberInHouse;
}
