using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace GOAP
{
    [GoapId("RestroomTargetSensor")]
    public class RestroomTargetSensor : LocalTargetSensorBase
    {
        //public override ISensorTimer Timer { get; } = SensorTimer.Once;
        public override ISensorTimer Timer { get; } = SensorTimer.Interval(1);
        
        private Transform restroomTransform;
        private BoxCollider restroomCollider;

        public override void Created()
        {
            restroomTransform = GameObject.FindGameObjectWithTag("Lounge").transform;
            
            restroomCollider = restroomTransform.GetComponent<BoxCollider>();
        }

        public override void Update()
        {
        }

        public override ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget)
        {
            Vector3 randomPoint = GetRandomPointInCollider();

            // Re-use the target if it already exists
            if (existingTarget is PositionTarget position)
            {
                return position.SetPosition(randomPoint);
            }

            return new PositionTarget(randomPoint);
        }

        private Vector3 GetRandomPointInCollider()
        {
            if (restroomCollider == null)
            {
                Debug.LogError("No collider found on the restroom!");
                
                return restroomTransform.position;
            }

            Vector3 center = restroomCollider.bounds.center;
            Vector3 size = restroomCollider.bounds.size;

            Vector3 randomPoint = new Vector3(
                Random.Range(center.x - size.x * 0.5f, center.x + size.x * 0.5f),
                0f,
                Random.Range(center.z - size.z * 0.5f, center.z + size.z * 0.5f)
            );

            return randomPoint;
        }
    }
}