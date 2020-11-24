using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIEnemyCounter : SingletonMonoBehaviour<UIEnemyCounter>
{
    public Text text;

    public void UpdateEnemyCounter(int count)
    {
        text.text = string.Format("Enemy Count : {0}", count);
    }
}
