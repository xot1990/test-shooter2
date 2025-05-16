using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEffect : MonoBehaviour
{
    public float time;
    private void Awake()
    {
        Destroy(gameObject,time);
    }
}
