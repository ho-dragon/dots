using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


//직접 작성한 MonoBehaviour에 IConvertGameObjectToEntity 인터페이스를 구현하면 
//ConvertToEntity가 기존 MonoBehaviour의 데이터를 Component로 변환해준다.
public class ParticleAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    //에디터 데이터 표시를 엔티티 최적의 런타임 표현으로 변환할 수 있습니다.
    void IConvertGameObjectToEntity.Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new ParticleEntity());

        //System으로 움직이려면 여기서 위치정보를 ComponentData로 변환해야한다.
    }

    //참조프리펩 정보에 현재 게임오브젝트 정보를 추가한다.
    void IDeclareReferencedPrefabs.DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(gameObject);
    }
}