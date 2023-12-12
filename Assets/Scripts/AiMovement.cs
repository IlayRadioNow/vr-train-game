using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    [SerializeField] private GameObject _handupObject,_finishPosition;

    private NavMeshAgent _agent;
    private LocateSit _locator;
    private Vector3 _position;

    public PassengerState MyState;

    // Start is called before the first frame update
    private void Start()
    {
        _position = _locator.SetTarget();
        _agent.SetDestination(_position);
    }

    private void Awake()
    {
        _locator = GetComponent<LocateSit>();
        _agent = GetComponent<NavMeshAgent>();
        MyState = PassengerState.OnBoard;
    }

    // Update is called once per frame
    public void HandUp()
    {   
        _handupObject.SetActive(true);   
    }

    private void OnArrivalDestroy()
    {
        print("Mystate: "+MyState);
        MyState++;
        if (MyState == PassengerState.DropOff)
        _agent.SetDestination(DropOffDestination.Target.position);
    }

    private void OnEnable()
    {
        StationTrigger.OnArrivalPassengerEvent += OnArrivalDestroy;
    }

    private void OnDisable()
    {
        StationTrigger.OnArrivalPassengerEvent -= OnArrivalDestroy;
    }
}

public enum PassengerState
{
    Start,
    OnBoard,
    DropOff
}
