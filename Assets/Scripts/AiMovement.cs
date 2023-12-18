using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    [SerializeField] private GameObject gameObject, _handupObject,_finishPosition;

    private NavMeshAgent _agent;
    private LocateSit _locator;
    private Vector3 _position;
    private Vector3 _NPCposition;
    private Animator animator;

    public PassengerState MyState;

    // Start is called before the first frame update
    private void Start()
    {
        _position = _locator.SetTarget();
        _agent.SetDestination(_position);
    }

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        _locator = GetComponent<LocateSit>();
        _agent = GetComponent<NavMeshAgent>();
        MyState = PassengerState.OnBoard;
        animator.SetInteger("state",2);
    }

    // Update is called once per frame
    public void HandUp()
    {   
        animator.SetInteger("state",4);
        transform.GetChild(6).gameObject.SetActive(true);
        //_handupObject.SetActive(true);
    }
    public void Sit()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        animator.SetInteger("state", 3);
        _agent.enabled = false;
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
