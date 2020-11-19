using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = Unity.Mathematics.Random;

public class EnemySpawner : MonoBehaviour
{
    [FormerlySerializedAs("SpawnRadiusMinMax")] public Vector2 spawnRadiusMinMax;
    [FormerlySerializedAs("SpawnCount")] public int spawnCount;
    private Random random;
    private int totalCount;
    private Action<int> onUpdateEnemyCount;
    void Awake()
    {
        random = new Random();
        random.InitState(10);
    }

    public void AddLinstener(Action<int> onUpdateEnemyCount)
    {
        this.onUpdateEnemyCount = onUpdateEnemyCount;
    }

    public void Spawn(GameObject prefabEnemy)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float randomAngle = random.NextFloat(0f, 360f);
            float randomDistance = random.NextFloat(spawnRadiusMinMax.x, spawnRadiusMinMax.y);
            float3 dir = math.mul(quaternion.RotateY(randomAngle), new float3(0, 0, 1));
            float3 spawnPos = dir * randomDistance;
            quaternion spawnRot = quaternion.LookRotationSafe(math.normalizesafe(-spawnPos), new float3(0f, 1f, 0f));
            GameObject.Instantiate(prefabEnemy, spawnPos, spawnRot);    
        }
        totalCount += spawnCount;
        this.onUpdateEnemyCount?.Invoke(totalCount);
    }
}
