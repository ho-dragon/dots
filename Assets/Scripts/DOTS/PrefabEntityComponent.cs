using Unity.Entities;

[GenerateAuthoringComponent]
public struct PrefabEntityComponent : IComponentData
{
    public Entity prefabEntity;
}

[GenerateAuthoringComponent]
public struct EnemyEntity : IComponentData
{
    
}
