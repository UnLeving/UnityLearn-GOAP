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
            //restroomTransform = GameObject.FindGameObjectWithTag("Lounge").transform;
        }

        public override void Update()
        {
        }
        
        public override SenseValue Sense(IActionReceiver agent, IComponentReference references)
        {
            var restroomBeh = references.GetCachedComponent<TiredBehaviour>();
            
            if (restroomBeh == null) return false;
            
            return new SenseValue(restroomBeh.AtRestroom);
        }
    }
}