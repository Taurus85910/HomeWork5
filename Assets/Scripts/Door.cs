using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{

    private SpriteRenderer _door;
<<<<<<< HEAD
    private bool _isAlarmOn;
=======
    private bool _isRobberInHouse;
>>>>>>> 624e08ac9e4d793d30c2215fc200f58273c8bb20
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
<<<<<<< HEAD
            if (!_isAlarmOn)          
                _isAlarmOn = true;                        
            else            
                _isAlarmOn = false;           
        }
    }
    public bool CheckAlarm() => _isAlarmOn;
=======
            if (!_isRobberInHouse)          
                _isRobberInHouse = true;                        
            else            
                _isRobberInHouse = false;           
        }
    }
    public bool CheckRobberInHouse() => _isRobberInHouse;
>>>>>>> 624e08ac9e4d793d30c2215fc200f58273c8bb20
}
