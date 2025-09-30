using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Runtime;

namespace GOAP
{
    [GoapId("Wander-df07b15f-a4be-4983-a124-5e167476e3d7")]
    public class WanderGoal : GoalBase
    {
        public override float GetCost(IActionReceiver agent, IComponentReference references)
        {
            return 10f;
        }
    }
}