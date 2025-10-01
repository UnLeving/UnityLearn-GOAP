using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace GOAP
{
    [GoapId("WanderTargetSensor")]
    public class WanderTargetSensor : LocalTargetSensorBase
    {
        public override ISensorTimer Timer { get; } = SensorTimer.Interval(1);

        private static readonly Vector2 Bounds = new Vector2(50, 8);
        
        int counter = 0;
        
        public override void Created()
        {
        }

        public override void Update()
        {
        }

        public override ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget)
        {
            var random = this.GetRandomPosition(agent);
            
            if (existingTarget is PositionTarget positionTarget)
                return positionTarget.SetPosition(random);
            
            return new PositionTarget(random);
        }
        
        private Vector3 GetRandomPosition(IActionReceiver agent)
        {
            if (counter > 100)
            {
                counter = 0;
                
                return agent.Transform.position;
            }
            
            counter++;
            var random =  Random.insideUnitCircle * 5f;
            var position = agent.Transform.position + new Vector3(random.x, 0f, random.y);
            
            if (position.x > -Bounds.x && position.x < Bounds.x && position.z > -Bounds.y && position.z < Bounds.y)
            {
                return position;
            }

            return this.GetRandomPosition(agent);
        }
    }
}