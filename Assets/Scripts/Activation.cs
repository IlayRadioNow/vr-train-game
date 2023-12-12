using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    [SerializeField] private GoTrainButton _goTrainButton;
    [SerializeField] private SetActiveTrigger _triggerActivator;

    private bool _wasPushed = false;
    private float _height;
    private Vector3 _startPosition;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _startPosition = transform.position;
        _height = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < _height && !_wasPushed)
        {
            _boxCollider.enabled = false;
            _triggerActivator.GoCoroutine();
            _goTrainButton.GoButtonPush();
            _wasPushed = true;
            StartCoroutine(Cooldown());
            transform.position = _startPosition;
        }

    }

    private IEnumerator Cooldown()
    {
        _wasPushed = true;
        yield return new WaitForSeconds(1);
        _wasPushed = false;
    }

    public void EnableCollider()
    {
        print("ENABLE COLLIDER"); 
        _boxCollider.enabled = true;
    }

    public void SubscribeOnEnable()
    {
        StationTrigger.ButtonEvent += EnableCollider;
    }
}
