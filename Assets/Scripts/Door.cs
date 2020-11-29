using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{

    private SpriteRenderer _door;
    private bool _isAlarmOn;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            if (!_isAlarmOn)          
                _isAlarmOn = true;                        
            else            
                _isAlarmOn = false;           
        }
    }
    public bool CheckAlarm() => _isAlarmOn;
}
