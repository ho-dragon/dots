﻿using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

[DisableAutoCreation]
public class EntitySpawnerSystem : ComponentSystem
{
    Random random;
    int totalCount;
    Action<int> onUpdateEnemyCount;
    
    protected override void OnCreate()
    {
        random = new Random();
        random.InitState(10);
        GameController.Instance.AddEventSpawn(Spawn);
    }

    public void Spawn(int spawnCount, Vector2 spawnRadiusMinMax, Vector3 targetPos)
    {
        Entities.ForEach((ref PrefabEntityComponent prefabEntityComponent) =>
        {
            for (int i = 0; i < spawnCount; i++)
            {
                float randomAngle = random.NextFloat(0f, 360f);
                float randomDistance = random.NextFloat(spawnRadiusMinMax.x, spawnRadiusMinMax.y);
                float3 dir = math.mul(quaternion.RotateY(randomAngle), new float3(0, 0, 1));
                float3 spawnPos = dir * randomDistance;
                quaternion spawnRot = quaternion.LookRotationSafe(math.normalizesafe(-spawnPos), new float3(0f, 1f, 0f));
                Entity spawnedEntity = EntityManager.Instantiate(prefabEntityComponent.prefabEntity);
                
                EntityManager.AddComponentObject(spawnedEntity, ParticleSystem.Instantiate(GameController.Instance.particleSystem));
                EntityManager.SetComponentData(spawnedEntity,
                    new Translation()
                    {
                        Value = spawnPos
                    });
                EntityManager.SetComponentData(spawnedEntity,
                    new Rotation()
                    {
                        Value = spawnRot
                    });
            }
        });
        totalCount += spawnCount;
        UIEnemyCounter.Instance.UpdateEnemyCounter(totalCount);
    }

    protected override void OnUpdate()
    {

    }
}
