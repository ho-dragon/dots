using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class ParticleMover : MonoBehaviour
{
    Random random;
    int totalCount;
    Action<int> onUpdateEnemyCount;
    List<Transform> particleTransformList = new List<Transform>();
    Vector3 targetPos;
    void Awake()
    {
        random = new Random();
        random.InitState(10);
    }

    public void Spawn(int spawnCount, Vector2 spawnRadiusMinMax, Vector3 targetPos)
    {
        this.targetPos = targetPos;
        
        for (int i = 0; i < spawnCount; i++)
        {
            float randomAngle = random.NextFloat(0f, 360f);
            float randomDistance = random.NextFloat(spawnRadiusMinMax.x, spawnRadiusMinMax.y);
            float3 dir = math.mul(quaternion.RotateY(randomAngle), new float3(0, 0, 1));
            float3 spawnPos = dir * randomDistance;
            quaternion spawnRot = quaternion.LookRotationSafe(math.normalizesafe(-spawnPos), new float3(0f, 1f, 0f));
            var particle = Instantiate(GameController.Instance.particleSystem);
            var particleTrans = particle.transform;
            particleTrans.position = spawnPos;
            particleTransformList.Add(particleTrans);
            particle.GetComponent<ParticleJob>().Init(targetPos);
        }
        totalCount += spawnCount;
        UIEnemyCounter.Instance.UpdateEnemyCounter(totalCount);
    }
    /*void Update()
    {
        for (int i = 0; i < particleTransformList.Count; i++)
        {
            particleTransformList[i].transform.position = Vector3.Lerp(particleTransformList[i].transform.position, this.targetPos, Time.deltaTime * 0.1f);
        }
    }*/
}
