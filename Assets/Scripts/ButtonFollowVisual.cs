using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    [SerializeField] private Transform _visualTarget;
    [SerializeField] private GoTrainButton _goTrainButton;
    [SerializeField] private Vector3 _localAxis;
    [SerializeField] private float _resetSpeed = 5;
    [SerializeField] private float _followAngleThreshold = 45;

    private XRBaseInteractable _interactable;
    private bool _isFollowing = false, _freeze = false;
    private Vector3 _offset, _initialLocalPosition;
    private Transform _pokeAttachTransform;

    // Start is called before the first frame update
    void Awake()
    {
        _interactable = GetComponent<XRBaseInteractable>();
        _interactable.hoverEntered.AddListener(Follow);
        _interactable.hoverExited.AddListener(Reset);
        _initialLocalPosition = _visualTarget.localPosition;
        _interactable.selectEntered.AddListener(Freeze);
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        _goTrainButton.GoButtonPush();
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;

            _isFollowing = true;
            _freeze = false;

            _pokeAttachTransform = interactor.attachTransform;
            _offset = _visualTarget.position - _pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(_offset, _visualTarget.TransformDirection(_localAxis));
            
            if (pokeAngle < _followAngleThreshold)
            {
                _isFollowing = true;
                _freeze = false;
            }
        }
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            _isFollowing = false;
            _freeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            _freeze = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.zKey.wasPressedThisFrame) {
            BaseInteractionEventArgs a = null;
            Follow(a);
        }
        if (_freeze) return;
        if (_isFollowing)
        {
            Vector3 localTargetPosition = _visualTarget.InverseTransformPoint(_pokeAttachTransform.position + _offset);
            Vector3 constraintLocalTargetPosiiton = Vector3.Project(localTargetPosition,_localAxis);
            _visualTarget.position = _visualTarget.TransformPoint(constraintLocalTargetPosiiton);
        }
        else
        {
            _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition,_initialLocalPosition,_resetSpeed * Time.deltaTime);
        }
    }
}
