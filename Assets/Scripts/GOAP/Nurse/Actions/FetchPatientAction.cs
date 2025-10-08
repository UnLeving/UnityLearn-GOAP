using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace GOAP
{
    [GoapId("FetchPatientAction")]
    public class FetchPatientAction : GoapActionBase<FetchPatientAction.Data>
    {
        public override bool IsValid(IActionReceiver agent, Data data)
        {
            //if(data.Target == null) return false;
            
            return true;
        }

        public override IActionRunState Perform(IMonoAgent agent, Data data, IActionContext context)
        {
            Debug.Log("FetchPatientAction.Perform");
            
            return ActionRunState.Completed;
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
        }

    }
}