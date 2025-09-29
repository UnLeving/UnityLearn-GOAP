using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;

namespace GOAP
{
    [GoapId("RestingWorldSensor")]
    public class RestingWorldSensor : LocalWorldSensorBase
    {
        public override void Created()
        {
        }

        public override void Update()
        {
        }

        public override SenseValue Sense(IActionReceiver agent, IComponentReference references)
        {
            var tiredBeh = references.GetCachedComponent<TiredBehaviour>();

            if (tiredBeh == null) return false;

            return tiredBeh.IsTired;
        }
    }
}