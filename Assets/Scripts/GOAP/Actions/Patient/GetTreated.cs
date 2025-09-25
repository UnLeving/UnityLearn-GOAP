public class GetTreated : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        
        if(target == null) return false;
        
        return true;
    }
    
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorldStates().AddOrModifyState("Treated", 1);
        agentBeliefs.AddOrModifyState("isCured", 1);
        inventory.RemoveItem(target);
        
        return true;
    }
}