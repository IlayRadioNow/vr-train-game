using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffDestination : MonoBehaviour
{
    public static Transform Target;

    private void Awake()
    {
        Target = transform;
    }
}
