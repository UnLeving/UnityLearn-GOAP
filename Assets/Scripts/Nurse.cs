using UnityEngine;

public class Nurse : GAgent
{
    protected override void Start()
    {
        base.Start();
        
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        subGoals.Add(s1, 3);
        SubGoal s2 = new SubGoal("resting", 1, false);
        subGoals.Add(s2, 1);
        
        Invoke(nameof(GetTired), Random.Range(10, 20));
    }

    private void GetTired()
    {
        beliefs.AddOrModifyState("exhausted", 0);
        
        Invoke(nameof(GetTired), Random.Range(10, 20));
    }
}