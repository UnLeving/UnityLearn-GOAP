using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SubGoal
{
    public Dictionary<string, int> sgoals;
    public bool remove;

    public SubGoal(string key, int value, bool remove)
    {
        sgoals = new Dictionary<string, int>();

        sgoals.Add(key, value);

        this.remove = remove;
    }
}

public class GAgent : MonoBehaviour
{
    public List<GAction> actions = new();
    public Dictionary<SubGoal, int> subGoals = new();
    public GAction currentAction;
    public GInventory inventory = new();
    public WorldStates beliefs = new();

    private GPlanner planner;
    private Queue<GAction> actionQueue = new();
    private SubGoal currentSubGoal;
    private bool invoked;

    protected virtual void Start()
    {
        var acts = GetComponents<GAction>();

        foreach (var act in acts)
        {
            actions.Add(act);
        }
    }

    private void CompleteAction()
    {
        currentAction.running = false;

        currentAction.PostPerform();

        invoked = false;
        
        Debug.Log("ACTION COMPLETE: " + currentAction.actionName);
    }

    private void LateUpdate()
    {
        if (currentAction != null && currentAction.running)
        {
            if (!currentAction.agent.hasPath || !(currentAction.agent.remainingDistance < 1f)) return;

            if (invoked) return;

            Invoke(nameof(CompleteAction), currentAction.duration);

            invoked = true;

            return;
        }

        if (planner == null || actionQueue == null)
        {
            planner = new GPlanner();

            var sortedGoals =
                from entry in subGoals
                orderby entry.Value descending
                select entry;

            foreach (var KVP in sortedGoals)
            {
                actionQueue = planner.plan(actions, KVP.Key.sgoals, beliefs);

                if (actionQueue == null) continue;

                currentSubGoal = KVP.Key;

                break;
            }
        }
        
        if (actionQueue != null && actionQueue.Count == 0)
        {
            if (currentSubGoal.remove)
            {
                subGoals.Remove(currentSubGoal);
            }

            planner = null;
        }

        if (actionQueue != null && actionQueue.Count > 0)
        {
            currentAction = actionQueue.Dequeue();

            if (currentAction.PrePerform())
            {
                if (currentAction.target == null && currentAction.targetTag != string.Empty)
                {
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);
                }

                if (currentAction.target != null)
                {
                    currentAction.agent.SetDestination(currentAction.target.transform.position);
                    currentAction.running = true;
                }
            }
            else
            {
                actionQueue = null;
            }
        }
    }
}