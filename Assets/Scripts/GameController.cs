using System;
using Unity.Entities;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
    public int spawnCount = 1000;
    public Vector2 spawnRadiusMinMax = new Vector2(15f, 60f);
    Action<int, Vector2> onSpawn;
    
    ComponentSystemGroup systemGroup;
    EntitySpawnerSystem spawnerSystem;
    MoveJobSystem moveJobSystem;
    void Start()
    {
        systemGroup = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<ComponentSystemGroup>();
        spawnerSystem = World.DefaultGameObjectInjectionWorld.CreateSystem<EntitySpawnerSystem>();
        systemGroup.AddSystemToUpdateList(spawnerSystem);
    }
    
    public void AddEventSpawn(Action<int, Vector2> onSpawn)
    {
        this.onSpawn = onSpawn;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.onSpawn?.Invoke(spawnCount, spawnRadiusMinMax);
            if (moveJobSystem == null)
            {
                moveJobSystem = World.DefaultGameObjectInjectionWorld.CreateSystem<MoveJobSystem>();
                moveJobSystem.Init(new Vector3(0,0,0));
                systemGroup.AddSystemToUpdateList(moveJobSystem);
            }
        }
    }
}
