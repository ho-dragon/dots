using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    Transform Target;
    private bool isExistTarget;
    float speed = 0.1f;

    public void Init(Transform target)
    {
        Target = target;
        isExistTarget = true;
        this.transform.LookAt(Target);
    }
    
    void Update()
    {
        if (isExistTarget)
        {
            transform.position = Vector3.Lerp(this.transform.position, Target.position, Time.deltaTime * speed);
        }
    }
}
