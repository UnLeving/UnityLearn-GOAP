using CrashKonijn.Agent.Core;
using CrashKonijn.Agent.Runtime;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace GOAP
{
    [GoapId("WaitingRoomAction")]
    public class WaitingRoomAction : GoapActionBase<WaitingRoomAction.Data>
    {
        public override IActionRunState Perform(IMonoAgent agent, Data data, IActionContext context)
        {
            data.MedicalCardBehaviour.waitingNurse = true;
            
            return ActionRunState.Completed;
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            [GetComponent]
            public MedicalCardBehaviour MedicalCardBehaviour { get; set; }
        }
    }
}