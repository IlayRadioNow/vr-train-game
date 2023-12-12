using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    public static Transform TransformOfPlayer;
    private void Awake()
    {
        TransformOfPlayer = transform;
    }
}
