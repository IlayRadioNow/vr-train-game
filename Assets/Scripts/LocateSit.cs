using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocateSit : MonoBehaviour
{
    private Vector3 _target;
    private Collider[] _sitColliders = new Collider[8]; 
    // Start is called before the first frame update
    void Awake()
    {
        int i = 0;
        Collider[] colliders = Physics.OverlapSphere(transform.position,1000f);
        foreach (var item in colliders)
        {
            if (item!= null && item.TryGetComponent(out Sit sit))
            {
                print(item);
                _sitColliders[i] = item;
                i++;
            }
        }
        ChooseSit();
        
    }

    public Vector3 SetTarget()
    {
        return _target;
    }

    private void ChooseSit()
    {
        int i = Random.Range(0, _sitColliders.Length);
        _sitColliders[i].TryGetComponent(out Sit chosenSit);
        if(chosenSit.IsOccupied)
        {
            ChooseSit();
        }
        else
        {
            _target = chosenSit.transform.position;
            chosenSit.IsOccupied = true;
            //Debug.Log(chosenSit.IsOccupied);
        }
        
    }
}
