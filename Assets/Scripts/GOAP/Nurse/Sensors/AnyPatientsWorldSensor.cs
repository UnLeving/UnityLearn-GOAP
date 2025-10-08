using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;

namespace GOAP
{
    [GoapId("AnyPatientsWorldSensor")]
    public class AnyPatientsWorldSensor : LocalWorldSensorBase
    {
        public override ISensorTimer Timer { get; } = SensorTimer.Interval(.5f);

        public override void Created()
        {
            
        }
        
        public override void Update()
        {
            
        }
        
        public override SenseValue Sense(IActionReceiver agent, IComponentReference references)
        {
            return new SenseValue(PatientsManager.Instance.HasPatients());
        }
    }
}