using System;
using Unity.Entities;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
    public int spawnCount = 1000;
    public Vector2 spawnRadiusMinMax = new Vector2(15f, 60f);
    Action<int, Vector2> onSpawn;
    public void AddEventSpawn(Action<int, Vector2> onSpawn)
    {
        this.onSpawn = onSpawn;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.onSpawn?.Invoke(spawnCount, spawnRadiusMinMax);
        }
    }
}
