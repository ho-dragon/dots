using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[DisableAutoCreation]
public class MoveJobSystem : ComponentSystem
{
    Vector3 targetPosition;

    public void Init(Vector3 target)
    {
        targetPosition = target;
    }

    protected override void OnUpdate()
    {
        Entities.WithAllReadOnly<EnemyEntity>().ForEach((ParticleSystem _particleDust, ref Translation _position) =>
        {
            _position.Value = Vector3.Lerp(_position.Value, targetPosition,  Time.DeltaTime * 0.1f);
            _particleDust.transform.position = _position.Value;
        });
    }
}