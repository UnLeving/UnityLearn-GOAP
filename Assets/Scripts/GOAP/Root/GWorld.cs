using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    public static readonly string Freecubicle = "FreeCubicle";
    public static readonly string Treatingpatient = "TreatingPatient";
    
    
    public static GWorld Instance { get; } = new();
    private static WorldStates _worldStates = new();
    private static Queue<GameObject> _patients = new();
    private static Queue<GameObject> _cubicles = new();

    static GWorld()
    {
        //     _worldStates = new WorldStates();

        var cubes = GameObject.FindGameObjectsWithTag("Cubicle");

        foreach (var cube in cubes)
        {
            _cubicles.Enqueue(cube);
        }

        if (_cubicles.Count > 0)
        {
            _worldStates.AddOrModifyState(Freecubicle, _cubicles.Count);
        }
    }

    // private GWorld()
    // {
    // }

    public void AddPatient(GameObject patient)
    {
        _patients.Enqueue(patient);
    }

    public GameObject GetPatient()
    {
        return _patients.Dequeue();
    }

    public void AddCubicle(GameObject cubicle)
    {
        _cubicles.Enqueue(cubicle);
    }

    public GameObject GetCubicle()
    {
        return _cubicles.Dequeue();
    }

    public WorldStates GetWorldStates()
    {
        return _worldStates;
    }
}