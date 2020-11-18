using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    private bool isExistTarget;

    public void Init(Transform target)
    {
        Target = target;
        isExistTarget = true;
    }
    
    void Update()
    {
        if (isExistTarget)
        {
            this.transform.LookAt(Target);
        }
    }
}
