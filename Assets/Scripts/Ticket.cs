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
        if (Terminal.RabbitsCount > 0)
        {
            int random = UnityEngine.Random.Range(0, 2);
            Terminal.RabbitsCount--;
            _isRabbit = Convert.ToBoolean(random);
        }
        else
        {
            _isRabbit=false;
        }
        transform.parent.parent.name = IsRabbit? "rabbit": transform.name;
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
        if (collision.collider.CompareTag("Terminal"))
        {
            if (IsRabbit)
            {
                collision.collider.TryGetComponent(out Terminal terminal);
                terminal.LightOn(IsRabbit);

                transform.parent.parent.TryGetComponent(out Rabbit rabbit);
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
