using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SetActiveTrigger : MonoBehaviour
{
    [SerializeField] private ButtonFollowVisual _button;
    [SerializeField] private GameObject _trigger;

    private static GameObject _triggerStatic;

    private void Awake()
    {
        _triggerStatic = _trigger;
    }

    public void GoCoroutine()
    {
        if(!_triggerStatic.activeSelf)
        StartCoroutine(WaitForTheStart());
    }
    private IEnumerator WaitForTheStart()
    {
        yield return new WaitForSeconds(2);
        _trigger.SetActive(true);
    }

    //private void Update()
    //{
    //    if (Keyboard.current.rKey.wasPressedThisFrame)
    //    {
    //        GoCoroutine();
    //    }
    //}
}
