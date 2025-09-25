using System.Collections.Generic;
using Helpers.TagSelector;
using UnityEngine;
using UnityEngine.AI;

public abstract class GAction : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1f;
    public GameObject target;
    
   [TagSelector] public string targetTag;
    public float duration = 0f;
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public NavMeshAgent agent;
    
    public Dictionary<string, int> preconditions;// = new Dictionary<string, int>();
    public Dictionary<string, int> effects;// = new Dictionary<string, int>();
    
    public WorldStates agentBeliefs;
    
    public GInventory inventory;

    public bool running;

    public GAction()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if (preConditions != null)
        {
            foreach (WorldState worldState in preConditions)
            {
                preconditions.Add(worldState.key, worldState.value);
            }
        }
        
        if (afterEffects != null)
        {
            foreach (WorldState worldState in afterEffects)
            {
                effects.Add(worldState.key, worldState.value);
            }
        }
        
        inventory = GetComponent<GAgent>().inventory;

        agentBeliefs = GetComponent<GAgent>().beliefs;
    }
    
    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach (var KVP in preconditions)
        {
            if(conditions.ContainsKey(KVP.Key) == false)
            {
                return false;
            }
        }

        return true;
    }
    
    public abstract bool PrePerform();
    public abstract bool PostPerform();
}