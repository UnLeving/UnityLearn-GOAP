using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;

namespace GOAP
{
    [GoapId("WaitingNurseWorldSensor")]
    public class WaitingNurseWorldSensor : LocalWorldSensorBase
    {
        private MedicalCardBehaviour medicalCardBehaviour;

        public override void Created()
        {
        }

        public override void Update()
        {
        }

        public override SenseValue Sense(IActionReceiver agent, IComponentReference references)
        {
            if (medicalCardBehaviour == null)
            {
                medicalCardBehaviour = references.GetCachedComponent<MedicalCardBehaviour>();
            }

            return medicalCardBehaviour.waitingNurse;
        }
    }
}