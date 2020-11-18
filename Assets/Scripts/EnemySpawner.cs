using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class EnemySpawner : MonoBehaviour
{
    public Vector2 SpawnRadiusMinMax;
    private Random random;
    public int SpawnCount;
    void Awake()
    {
        random = new Random();
        random.InitState(10);
    }

    public void Spawn(GameObject prefabEnemy)
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            float randomAngle = random.NextFloat(0f, 360f);
            float randomDistance = random.NextFloat(SpawnRadiusMinMax.x, SpawnRadiusMinMax.y);
            float3 dir = math.mul(quaternion.RotateY(randomAngle), new float3(0, 0, 1));
            float3 spawnPos = dir * randomDistance;
            quaternion spawnRot = quaternion.LookRotationSafe(math.normalizesafe(-spawnPos), new float3(0f, 1f, 0f));
            GameObject.Instantiate(prefabEnemy, spawnPos, spawnRot);    
        }
    }
}
