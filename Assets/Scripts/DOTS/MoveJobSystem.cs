using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[DisableAutoCreation]
public class MoveJobSystem : JobComponentSystem
{
    Vector3 targetPosition;

    public void Init(Vector3 target)
    {
        targetPosition = target;
    }
    
    struct MoveJob : IJobForEach<EnemyEntity, Translation>
    {
        public float3 target;
        public float speed;
        public void Execute([ReadOnly] ref EnemyEntity entity, ref Translation translation)
        {
            translation.Value = Vector3.Lerp(translation.Value, target, speed);
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var moveJob = new MoveJob
        {
            target = targetPosition,
            speed = Time.DeltaTime * 0.1f
        }.Schedule(this, inputDeps);
        return moveJob;
    }
}
