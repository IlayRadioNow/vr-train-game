using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyPassenger : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Rabbit rabbit) && rabbit.enabled)
        {
            TextUpdater.UpdateHPText();
            Destroy(other.gameObject);

        }
        else if (other.TryGetComponent(out AiMovement aiMovement))
        {
            Destroy(other.gameObject);
        }
    }
}
