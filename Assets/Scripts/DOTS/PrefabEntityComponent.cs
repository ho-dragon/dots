using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

// [GenerateAuthoringComponent]
// public struct PrefabEntityComponent : IComponentData
// {
//     public Entity prefabEntity;
// }

[GenerateAuthoringComponent]
public struct ParticleEntity : IComponentData
{
    public Entity prefabEntity;
}
