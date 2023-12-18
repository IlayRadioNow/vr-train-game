using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : MonoBehaviour
{
    private bool _isOccupied;
    public bool IsOccupied {
        get { return _isOccupied; }
        set { _isOccupied = value; }
    } 

    private void Awake()
    {
        _isOccupied = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        print("colider");
        /*if (other.TryGetComponent(out AiMovement aiMovement))
        {
            aiMovement.HandUp();
            aiMovement.Sit();
        }*/
    }

    private void SitReset()
    {
        _isOccupied = false;
    }

    private void OnEnable()
    {
        StationTrigger.OnArrivalEvent += SitReset;
    }

    private void OnDisable()
    {
        StationTrigger.OnArrivalEvent -= SitReset;
    }
}
