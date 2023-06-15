using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public virtual void attack()
    {
        Debug.Log("Mainclass");
    }

    public virtual void Update()
    {
        Debug.Log("Main Update");
    }
}
