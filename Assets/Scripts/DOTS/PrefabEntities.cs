﻿using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PrefabEntities : MonoBehaviour, IConvertGameObjectToEntity
{
    public static Entity prefabEntity;
    public GameObject prefabGameObject;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        using (BlobAssetStore blobAssetStore = new BlobAssetStore())
        {
            Entity prefabEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefabGameObject
                , GameObjectConversionSettings.FromWorld(dstManager.World, blobAssetStore));
            
            PrefabEntities.prefabEntity = prefabEntity;
        }
    }
}
