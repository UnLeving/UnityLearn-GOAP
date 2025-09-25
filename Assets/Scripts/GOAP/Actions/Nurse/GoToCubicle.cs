public class GoToCubicle : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        
        if(target == null) return false;
        
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorldStates().AddOrModifyState(GWorld.Treatingpatient, 1);
        GWorld.Instance.AddCubicle(target);
        
        inventory.RemoveItem(target);
        
        GWorld.Instance.GetWorldStates().AddOrModifyState(GWorld.Freecubicle, 1);
        
        return true;
    }
}