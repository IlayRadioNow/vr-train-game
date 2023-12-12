using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _passenger;
    [SerializeField] private float _awaitTime = 3;

    private float _spawnHeight;

    private void Awake()
    {
        _spawnHeight = _passenger.GetComponent<CapsuleCollider>().height / 2;
    }

    public void Spawn()
    {
        //print("public Spawn" + transform.parent.name);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_awaitTime);
        int index = Random.Range(2, 5);
        for (int i = 0; i < index; i++)
        {
            Instantiate(_passenger, transform.position + new Vector3(0, _spawnHeight, 0), Quaternion.identity);
        }
    }
}
