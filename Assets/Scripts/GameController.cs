using System;
using Unity.Entities;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
    public int spawnCount = 1000;
    public Vector2 spawnRadiusMinMax = new Vector2(15f, 60f);
    public Transform playerTransform;
    public ParticleSystem particleSystem;
    public ParticleMover particleMover;
    public bool IsEnableDOTS = false;
    Action<int, Vector2, Vector3> onSpawn;
    ComponentSystemGroup systemGroup;
    EntitySpawnerSystem spawnerSystem;
    MoveJobSystem moveJobSystem;
    
    void Start()
    {
        systemGroup = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<ComponentSystemGroup>();
        spawnerSystem = World.DefaultGameObjectInjectionWorld.CreateSystem<EntitySpawnerSystem>();
        systemGroup.AddSystemToUpdateList(spawnerSystem);
    }
    
    public void AddEventSpawn(Action<int, Vector2, Vector3> onSpawn)
    {
        this.onSpawn = onSpawn;
    }
    
    public void OnClickSpawnEnemy()
    {
        if (IsEnableDOTS)
        {
            this.onSpawn?.Invoke(spawnCount, spawnRadiusMinMax, playerTransform.position);
        
            if (moveJobSystem == null)
            {
                moveJobSystem = World.DefaultGameObjectInjectionWorld.CreateSystem<MoveJobSystem>();
                moveJobSystem.Init(playerTransform.position);
                systemGroup.AddSystemToUpdateList(moveJobSystem);
            }       
        }
        else
        {
            particleMover.Spawn(spawnCount, spawnRadiusMinMax, playerTransform.position);
        }
    }
}
