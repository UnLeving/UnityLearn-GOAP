using System;
using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Runtime;
using Random = UnityEngine.Random;

namespace GOAP
{
    [GoapId("Wander-f803d09f-39b1-4ef8-b710-56b0770cc27f")]
    public class WanderAction : GoapActionBase<WanderAction.Data, WanderAction.Props>
    {

        // This method is called when the action is started
        // This method is optional and can be removed
        public override void Start(IMonoAgent agent, Data data)
        {
            data.Timer = Random.Range(this.Properties.minTimer, this.Properties.maxTimer);
        }
        
        // This method is called every frame while the action is running
        // This method is required
        public override IActionRunState Perform(IMonoAgent agent, Data data, IActionContext context)
        {
            return ActionRunState.WaitThenComplete(data.Timer);
        }
        
        // The action class itself must be stateless!
        // All data should be stored in the data class
        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            public float Timer { get; set; }
        }
        
        [Serializable]
        public class Props : IActionProperties
        {
            public float minTimer;
            public float maxTimer;
        }
    }
}