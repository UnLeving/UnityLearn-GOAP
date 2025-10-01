using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace GOAP
{
    [GoapId("RegistrationZoneSensor")]
    public class RegistrationZoneSensor : LocalTargetSensorBase
    {
        public override ISensorTimer Timer { get; } = SensorTimer.Once;
        
        private Transform registrationZoneTransform;
        
        public override void Created()
        {
            registrationZoneTransform = GameObject.FindGameObjectWithTag("Reception").transform;
        }

        public override void Update()
        {
        }

        public override ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget)
        {
            return new PositionTarget(registrationZoneTransform.position);
        }
    }
}