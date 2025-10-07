using System;
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
        
        this.provider.RequestGoal<WanderGoal>(true);
    }

    private void OnDestroy()
    {
        this.provider.Events.OnNoActionFound -= this.OnNoActionFound;
        this.provider.Events.OnGoalCompleted -= this.OnGoalCompleted;
    }
    
    private void OnNoActionFound(IGoalRequest request)
    {
        this.provider.RequestGoal<WanderGoal>(true);
    }
    
    private void OnGoalCompleted(IGoal goal)
    {
        this.provider.RequestGoal<WanderGoal>(true);
    }

    private void Update()
    {
        if (this.tiredBehaviour.IsTired)
        {
            this.provider.RequestGoal<FixTiredGoal>(true);
        }
        else
            this.provider.RequestGoal<WanderGoal>(true);
    }
}