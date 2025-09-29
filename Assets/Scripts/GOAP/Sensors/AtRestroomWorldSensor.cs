using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace GOAP
{
    [GoapId("AtRestroomWorldSensor")]
    public class AtRestroomWorldSensor : LocalWorldSensorBase
    {
        private Transform restroomTransform;
        
        public override void Created()
        {
            restroomTransform = GameObject.FindGameObjectWithTag("Lounge").transform;
        }

        public override void Update()
        {
        }

        public override SenseValue Sense(IActionReceiver agent, IComponentReference references)
        {
            var flag = Vector3.Distance(agent.Transform.position, restroomTransform.position) < 2f;
            
            return flag;
        }
    }
}