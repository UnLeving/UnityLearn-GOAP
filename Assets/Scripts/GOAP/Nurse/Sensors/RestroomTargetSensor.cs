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
                return restroomTransform.position;

            Vector3 localCenter = restroomCollider.center;
            Vector3 size = restroomCollider.size;

            Vector3 localRandomPoint = new Vector3(
                localCenter.x + Random.Range(-size.x * 0.5f, size.x * 0.5f),
                localCenter.y,
                localCenter.z + Random.Range(-size.z * 0.5f, size.z * 0.5f)
            );

            Vector3 worldPoint = restroomTransform.TransformPoint(localRandomPoint);
            
            return worldPoint;
        }
    }
}