using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


//ECS는 데이터(data)와 로직(functionality)을 분리해서 처리하는데,
// 데이터는 Component에 저장하고 로직은 System으로 구현한다.
[DisableAutoCreation]
public class MoveJobSystem : ComponentSystem
{
    Vector3 targetPosition;

    public void Init(Vector3 target)
    {
        targetPosition = target;
    }

//ComponentSystem을 상속받아 작성한 MoveJobSystemd은
// Entities.ForEach 구문으로 각 Entity를 반복(iterate) 처리한다.
// 이 예제에는 Entity가 딱 한 개지만, 더 많은 Entity를 씬에 추가하면
// MoveJobSystem 씬에 존재하는 모든 Entity의 데이터를 갱신한다. 

//단, 해당 Entity는 Position Component를 갖고 있어야 한다.
//결국 원하는 게임오브젝트에 Monobehavior,IConvertGameObjectToEntity를 구현하고
//ConvertToEntity를 여서 Entity로 변환하는 과정에서 IConvertGameObjectToEntity를 구현했으므로
// 그과정에서 Component 데이터를 만들어 Position에 넣어줌
    protected override void OnUpdate()
    {
        Entities.WithAllReadOnly<ParticleEntity>().ForEach((ParticleSystem _particleDust, ref Translation _position) =>
        {
            _position.Value = Vector3.Lerp(_position.Value, targetPosition,  Time.DeltaTime * 0.1f);
            _particleDust.transform.position = _position.Value;
        });
    }
}