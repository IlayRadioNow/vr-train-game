using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    private Material _defaultMaterial;
    private Animator _animator;
    private int _rabbitsCount;

    public int getRabbits() => _rabbitsCount;
    public void plusRabbit() => _rabbitsCount--;
    public int minusRabbit() => _rabbitsCount++;


    private void Awake()
    {
        _rabbitsCount = 2;
        _animator = GetComponent<Animator>();
        _animator.SetInteger("state", 3);
    }

    public void LightOn(bool isRabbit)
    {
        StopAllCoroutines();
        if (isRabbit)
        {
            _animator.SetInteger("state", 1);
            StartCoroutine(Evaluate());
        }
        else
        {
            _animator.SetInteger("state", 2);
            StartCoroutine(Evaluate());
        }
    }

    private IEnumerator Evaluate()
    {
        yield return new WaitForSeconds(5f);
        _animator.SetInteger("state", 3);

    }
}
