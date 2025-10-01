using CrashKonijn.Agent.Core;
using CrashKonijn.Agent.Runtime;
using CrashKonijn.Goap.Runtime;

namespace GOAP
{
    [GoapId("GoToRestroom-d91a1031-05cd-4847-90c0-88d8e80daec8")]
    public class GoToRestroomAction : GoapActionBase<GoToRestroomAction.Data>
    {
        // This method is called every frame while the action is running
        // This method is required
        public override IActionRunState Perform(IMonoAgent agent, Data data, IActionContext context)
        {
            data.TiredBehaviour.AtRestroom = true;
            
            return ActionRunState.Completed;
        }
        
        // The action class itself must be stateless!
        // All data should be stored in the data class
        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            [GetComponent]
            public TiredBehaviour TiredBehaviour { get; set; }
        }
    }
}