using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainNavMesh : MonoBehaviour
{
    public static Transform Area;
    private void Awake()
    {
        Area = transform;
    }
}
