using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] private Material _red, _green;
    [SerializeField] private MeshRenderer _renderer;
    private Material _defaultMaterial;
    public static int RabbitsCount;

    private void Awake()
    {
        RabbitsCount = 2;
        _defaultMaterial = _renderer.material;
    }

    public void LightOn(bool isRabbit)
    {
        StopAllCoroutines();
        if (isRabbit)
        {
            _renderer.material = _green;
            StartCoroutine(Evaluate());
        }
        else
        {
            _renderer.material = _red;
            StartCoroutine(Evaluate());
        }
    }

    private IEnumerator Evaluate()
    {
        yield return new WaitForSeconds(5f);
        _renderer.material = _defaultMaterial;

    }
}
