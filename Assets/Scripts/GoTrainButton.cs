using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoTrainButton : MonoBehaviour
{
    [SerializeField] private Movable _station1, _station2;
    [SerializeField] private float _inMoveTime = 20;
    [SerializeField] private GameObject[] _doors;
    private Animator[] _animators= new Animator[5];
   

    public void GoButtonPush()
    {
        
        for(var i = 0; i < _doors.Length; i++)
        {
            _animators[i] = _doors[i].GetComponent<Animator>();
            _animators[i].SetInteger("state", 1);
        }
        _station1.StartMove();
        _station2.StartMove();
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            GoButtonPush();
        }
    }

}
