using UnityEngine;

public class GetPatient : GAction
{

    private GameObject resource;
    
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetPatient();
        
        if(target == null) return false;
        
        resource = GWorld.Instance.GetCubicle();

        if (resource != null)
        {
            inventory.AddItem(resource);
        }
        else
        {
            // no resource, add patient to world
            GWorld.Instance.AddPatient(target);
            
            target = null;
            
            return false;
        }
        
        GWorld.Instance.GetWorldStates().AddOrModifyState(GWorld.Freecubicle, -1);
        
        return true;
    }

    public override bool PostPerform()
    {
        //GWorld.Instance.GetWorldStates().AddOrModifyState("FreeCubicle", 1);
        GWorld.Instance.GetWorldStates().AddOrModifyState("waiting", -1);

        if (target)
        {
            target.GetComponent<GAgent>().inventory.AddItem(resource);
        }
        
        return true;
    }
}