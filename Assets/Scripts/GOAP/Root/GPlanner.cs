using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string, int> states;
    public GAction action;

    public Node(Node parent, float cost, Dictionary<string, int> allStates, GAction action)
    {
        this.action = action;
        this.states = new Dictionary<string, int>(allStates);
        this.parent = parent;
        this.cost = cost;
    }
    
    public Node(Node parent, float cost, Dictionary<string, int> allStates, Dictionary<string, int> beliefStates,GAction action)
    {
        this.action = action;
        this.states = new Dictionary<string, int>(allStates);

        foreach (var KVP in beliefStates)
        {
            if (this.states.ContainsKey(KVP.Key) == false)
            {
                this.states.Add(KVP.Key, KVP.Value);
            }
        }
        
        this.parent = parent;
        this.cost = cost;
    }
}

public class GPlanner
{
    public Queue<GAction> plan(List<GAction> actions, Dictionary<string, int> goal, WorldStates beliefStates)
    {
        List<GAction> usableActions = new List<GAction>();

        foreach (GAction action in actions)
        {
            if (action.IsAchievable() == false) continue;

            usableActions.Add(action);
        }

        List<Node> leaves = new List<Node>();

        Node start = new Node(null, 0, GWorld.Instance.GetWorldStates().GetStates(), beliefStates.GetStates() ,null);

        bool success = BuildGraph(start, leaves, usableActions, goal);

        if (!success)
        {
            Debug.Log("NO PLAN FOUND");

            return null;
        }

        Node cheapestNode = null;

        foreach (Node leaf in leaves)
        {
            if (cheapestNode == null)
            {
                cheapestNode = leaf;
            }
            else
            {
                if (leaf.cost < cheapestNode.cost)
                {
                    cheapestNode = leaf;
                }
            }
        }

        List<GAction> result = new();
        Node node = cheapestNode;

        while (node != null)
        {
            if (node.action != null)
            {
                result.Insert(0, node.action);
            }

            node = node.parent;
        }

        Queue<GAction> queue = new();

        foreach (GAction action in result)
        {
            queue.Enqueue(action);
        }

        Debug.Log("PLAN FOUND: ");

        foreach (GAction action in queue)
        {
            Debug.Log("Q: " + action.actionName);
        }

        return queue;
    }

    private bool BuildGraph(Node parent, List<Node> leaves, List<GAction> usableActions, Dictionary<string, int> goal)
    {
        bool foundPath = false;

        foreach (GAction action in usableActions)
        {
            if (action.IsAchievableGiven(parent.states))
            {
                Dictionary<string, int> currentState = new(parent.states);

                foreach (var KVP in action.effects)
                {
                    if (currentState.ContainsKey(KVP.Key)) continue;

                    currentState.Add(KVP.Key, KVP.Value);
                }

                Node node = new Node(parent, parent.cost + action.cost, currentState, action);

                if (GoalAchieved(goal, currentState))
                {
                    leaves.Add(node);

                    foundPath = true;
                }
                else
                {
                    List<GAction> subset = ActionSubset(usableActions, action);

                    bool found = BuildGraph(node, leaves, subset, goal);

                    if (found)
                    {
                        foundPath = true;
                    }
                }
            }
        }

        return foundPath;
    }

    private bool GoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
    {
        foreach (var KVP in goal)
        {
            if (state.ContainsKey(KVP.Key) == false)
            {
                return false;
            }
        }

        return true;
    }

    private List<GAction> ActionSubset(List<GAction> actions, GAction removeMe)
    {
        List<GAction> subset = new();

        foreach (GAction action in actions)
        {
            if (action.Equals(removeMe)) continue;

            subset.Add(action);
        }

        return subset;
    }
}