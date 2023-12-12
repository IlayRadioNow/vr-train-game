using System;
using UnityEngine;

public class StationTrigger : MonoBehaviour
{
    [SerializeField] private GoTrainButton _goTrainButton;
    [SerializeField] private Door _door;
    [SerializeField] private Activation _activator;
    public static event Action OnArrivalEvent,OnArrivalPassengerEvent,ButtonEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Spawner spawner))
        {
            //print("OnEnterSPAWN");
            spawner.Spawn();
            OnArrivalPassengerEvent?.Invoke();
            ButtonEvent?.Invoke();
        }
        if (other.CompareTag("Floor"))
        {
            print("Enter");
            _door.ButtonPushed = false;
            _door.ActPublic();
            _door.ButtonPushed = true;

            Movable.InMove = false;
            Movable movable = other.GetComponent<Movable>();
            movable.IsByTrain = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            print("Exit");
            OnArrivalEvent?.Invoke();

            _door.ButtonPushed = false;
            _door.ActPublic();
            _door.ButtonPushed = true;
            
            Movable.InMove = true;
            Movable movable  = other.GetComponent<Movable>();
            movable.IsByTrain = false;
        }
    }

    private void OnEnable()
    {
        _activator.SubscribeOnEnable();
    }

}
