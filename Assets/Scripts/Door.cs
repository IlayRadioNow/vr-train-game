using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _stationTrigger;
    private float _x;
    private int _direction = 1;

    private bool _buttonPushed = false;

    public bool ButtonPushed
    {
        get { return _buttonPushed; }
        set { _buttonPushed = value; }
    }

    private void Awake()
    {
        _x = GetComponent<BoxCollider>().bounds.size.x;
    }

    public void ActPublic()
    {
        Act();
    }
    private void Act()
    {
        
        if (_buttonPushed) return;
        _x = GetComponent<BoxCollider>().bounds.size.x;
        _buttonPushed = true;
        transform.position += _direction * new Vector3(_x, 0, 0);
            _direction *= -1;
            //print("DOOR ACTED");
    }

}
