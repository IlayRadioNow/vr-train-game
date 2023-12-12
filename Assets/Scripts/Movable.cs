using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movable : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _startPoint;

    private static bool _inMove = false;
    private bool _IsByTrain;
    
    public bool IsByTrain
    {
        get { return _IsByTrain; }
        set { _IsByTrain = value; }
    }
    public static bool InMove {
        get { return _inMove; }
        set { _inMove = value; }
    }

    public void StartMove()
    {
        StopAllCoroutines();
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        print(gameObject.name);
        _inMove = true;
        while (_inMove) 
        {
            transform.position += new Vector3(Time.deltaTime * 10f * _speed, 0, 0);
            yield return null;
        }
        _inMove = false;
    }

    private void Translate()
    {
        print("Translate");
        if(!_IsByTrain && _startPoint!=null)
        transform.position = _startPoint.position;
    }

    private void OnEnable()
    {
        StationTrigger.OnArrivalEvent += Translate; 
    }

    public void OnDisable()
    {
        StationTrigger.OnArrivalEvent -= Translate;
    }
}
