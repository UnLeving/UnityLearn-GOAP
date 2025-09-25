using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WorldState
{
    public string key;
    public int value;
}

public class WorldStates
{
    public Dictionary<string, int> states;

    public WorldStates()
    {
        states = new Dictionary<string, int>();
    }
    
    public bool HasState(string key)
    {
        return states.ContainsKey(key);
    }

    private void AddState(string key, int value)
    {
        states.Add(key, value);
    }

    public void RemoveState(string key)
    {
        if (!HasState(key)) return;
        
        states.Remove(key);
    }
    
    public void AddOrModifyState(string key, int value)
    {
        if (HasState(key))
        {
            states[key] += value;
            
            if (states[key] <= 0)
            {
                RemoveState(key);
            }
        }
        else
        {
            AddState(key, value);
        }
    }
    
    public void SetState(string key, int value)
    {
        if (HasState(key))
        {
            states[key] = value;
        }
        else
        {
            AddState(key, value);
        }
    }

    public Dictionary<string, int> GetStates()
    {
        return states;
    }
}