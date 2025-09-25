public class GoToWaitingRoom : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorldStates().AddOrModifyState("waiting", 1);
        GWorld.Instance.AddPatient(gameObject);
        
        agentBeliefs.AddOrModifyState("atHospital", 1);
        
        return true;
    }
}