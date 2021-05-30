using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class ParticleJobTest : MonoBehaviour
{
    private ParticleSystem ps;
    private UpdateParticlesJob job = new UpdateParticlesJob();
    Vector3 targetPos;
    void Start ()
    {
        ps = GetComponent<ParticleSystem>();
        job.color = Color.white;
    }

    public void Init(Vector3 targetPosition)
    {
        targetPos = targetPosition;
    }

    void Update()
    {
        job.speed = Time.deltaTime * 0.1f;
    }

    void OnParticleUpdateJobScheduled()
    {
        /*var handle =*/ job.Schedule(ps);
    }
 
    [BurstCompile]// Enable if using the Burst package
    struct UpdateParticlesJob : IJobParticleSystem
    {
        public Vector3 targetPos;
        public float speed;
        public Color color;
        
        public void Execute(ParticleSystemJobData particles)
        {
            var startColors = particles.startColors;
            var positions = particles.positions;
 
            for (int i = 0; i < particles.count; i++)
            {
                startColors[i] = color;
                positions[i] = Vector3.Lerp(positions[i], targetPos, speed);
            }
        }
    }
}