using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    private Rabbit _rabbit;
    private bool _isRabbit;
    public bool IsRabbit => _isRabbit;

    private void Start()
    {
        float random = Mathf.Round(UnityEngine.Random.Range(0.0f, 1.0f)) ;
        if (random == 1)
        {
            _isRabbit = Convert.ToBoolean(random);
        }
        else
        {
            _isRabbit=false;
        }
        transform.name = IsRabbit? "rabbit": transform.name;
        print("random");
        print(random);
            print("IsRabbit = "+ IsRabbit + " " + transform.position);
        
        if (IsRabbit)
        {
            transform.parent.TryGetComponent(out Rabbit rabbit);
            _rabbit = rabbit;
        }

    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        print("Yes1");
        if (collision.collider.CompareTag("Terminal"))
        {
            print("Yes");
            if (IsRabbit)
            {
                collision.collider.TryGetComponent(out Terminal terminal);
                terminal.LightOn(IsRabbit);

                transform.parent.TryGetComponent(out Rabbit rabbit);
                _rabbit = rabbit;
                _rabbit.enabled = true;
            }
            else
            {
                collision.collider.TryGetComponent(out Terminal terminal);
                terminal.LightOn(IsRabbit);
            }
            gameObject.SetActive(false);
            

        }
    }
}
