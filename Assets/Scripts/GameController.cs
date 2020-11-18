using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform Player;
    public GameObject EnemyPrefab;
    public EnemySpawner Spawner;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spawner.Spawn(EnemyPrefab);
        }
    }
}
