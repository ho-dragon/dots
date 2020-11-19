using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIEnemyCounter : MonoBehaviour
{
    public Text text;
    public EnemySpawner spawner;
    
    void Start()
    {
        spawner.AddLinstener(OnUpdateEnemyCounter);
    }

    void OnUpdateEnemyCounter(int count)
    {
        text.text = string.Format("Enemy Count : {0}", count);
    }
}
