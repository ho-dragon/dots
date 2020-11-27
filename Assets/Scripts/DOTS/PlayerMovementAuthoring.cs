using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


public class PlayerMovementAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    void IConvertGameObjectToEntity.Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new EnemyEntity());
    }

    void IDeclareReferencedPrefabs.DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(gameObject);
    }
}