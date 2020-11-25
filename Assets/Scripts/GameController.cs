using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform Player;
    public GameObject EnemyPrefab;
    public EnemySpawner Spawner;
    
    public void OnClickSpawnEnemy()
    {
        Spawner.Spawn(EnemyPrefab, Player);
    }
}
