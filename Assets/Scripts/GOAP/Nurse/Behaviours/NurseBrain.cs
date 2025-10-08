using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using GOAP;
using UnityEngine;

public class NurseBrain : MonoBehaviour
{
    private GoapActionProvider provider;
    private TiredBehaviour tiredBehaviour;

    private void Awake()
    {
        this.provider = this.GetComponent<GoapActionProvider>();
        tiredBehaviour = GetComponent<TiredBehaviour>();
    }

    private void Start()
    {
        this.provider.Events.OnNoActionFound += this.OnNoActionFound;
        this.provider.Events.OnGoalCompleted += this.OnGoalCompleted;
        
        //RequestWanderGoal();

        RequestAssistPatientGoal();
    }

    private void OnDestroy()
    {
        this.provider.Events.OnNoActionFound -= this.OnNoActionFound;
        this.provider.Events.OnGoalCompleted -= this.OnGoalCompleted;
    }
    
    private void RequestWanderGoal()
    {
        this.provider.RequestGoal<WanderGoal>(true);
    }
    
    private void RequestAssistPatientGoal()
    {
        this.provider.RequestGoal<AssistPatientsGoal>(true);
    }
    
    private void RequestFixTiredGoal()
    {
        this.provider.RequestGoal<FixTiredGoal>(true);
    }
    
    private void OnNoActionFound(IGoalRequest request)
    {
        //RequestWanderGoal();
    }
    
    private void OnGoalCompleted(IGoal goal)
    {
        //RequestWanderGoal();
    }

    private void Update()
    {
        if (this.tiredBehaviour.IsTired)
        {
            RequestFixTiredGoal();
        }
        else
        {
            //RequestWanderGoal();
        }
    }
}