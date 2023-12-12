using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoTrainButton : MonoBehaviour
{
    [SerializeField] private Movable _station1, _station2;
    [SerializeField] private float _inMoveTime = 20;
    [SerializeField] private Door _door;
   

    public void GoButtonPush()
    {
        _door.ActPublic();
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
