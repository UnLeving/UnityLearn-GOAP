using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Runtime;

namespace GOAP
{
    [GoapId("AssistPatientsGoal")]
    public class AssistPatientsGoal : GoalBase
    {
        public override float GetCost(IActionReceiver agent, IComponentReference references)
        {
            return 1f;
        }
    }
}