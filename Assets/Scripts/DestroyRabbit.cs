using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRabbit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Handcuffs"))
        {
            TextUpdater.UpdateText();
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Handcuffs"))
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Handcuffs"))
        {
            Destroy(transform.parent.gameObject);
        }
    }

}
