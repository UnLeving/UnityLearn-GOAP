using CrashKonijn.Agent.Core;
using CrashKonijn.Agent.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class DistanceObserver : MonoBehaviour, IAgentDistanceObserver
{
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.GetComponent<AgentBehaviour>().DistanceObserver = this;
    }

    public float GetDistance(IMonoAgent agent, ITarget target, IComponentReference reference)
    {
        if(target == null) return 0f;
        
        float distance = 0;
        if(navMeshAgent != null && navMeshAgent.isActiveAndEnabled)
        {
            distance = this.navMeshAgent.remainingDistance;
        }
        else
        {
            var from = new Vector3(agent.Transform.position.x, 0f, agent.Transform.position.z);
            var to = new Vector3(target.Position.x, 0f, target.Position.z);
            
            distance = Vector3.Distance(from, to);
        }
        // No path
        if (float.IsInfinity(distance))
            return 0f;

        return distance;
    }
}