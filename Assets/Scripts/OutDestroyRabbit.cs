using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutDestroyRabbit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.TryGetComponent(out DestroyRabbit rabbit))
        {
            if(!rabbit.transform.parent.GetComponent<MeshRenderer>().enabled)
            {
                print(rabbit.transform.parent.name + "   " + rabbit.transform.parent.GetComponent<MeshRenderer>().enabled);
                TextUpdater.UpdateHPText();
                Destroy(other.transform.parent.gameObject);
            }

        }
    }
}
