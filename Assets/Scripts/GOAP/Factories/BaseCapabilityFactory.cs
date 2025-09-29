using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace GOAP
{
    [CreateAssetMenu(menuName = "Goap/Custom/BaseCapabilityFactory")]
    public class BaseCapabilityFactory : ScriptableCapabilityFactoryBase
    {
        public override ICapabilityConfig Create()
        {
            var builder = new CapabilityBuilder("BaseCapability");

            builder.AddTargetSensor<AgentSensor>()
                .SetTarget<AgentTarget>();

            return builder.Build();
        }
    }
}