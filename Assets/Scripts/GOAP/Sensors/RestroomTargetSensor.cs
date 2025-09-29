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

        public override void Created()
        {
            restroomTransform = GameObject.FindGameObjectWithTag("Lounge").transform;
        }

        public override void Update()
        {
        }

        public override ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget)
        {
            // Re-use the target if it already exists
            if (existingTarget is PositionTarget position)
            {
                return position.SetPosition(restroomTransform.position);
            }
            
            return new PositionTarget(restroomTransform.position);
        }
    }
}