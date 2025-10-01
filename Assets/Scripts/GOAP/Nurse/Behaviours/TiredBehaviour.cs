using CrashKonijn.Goap.Runtime;
using UnityEngine;

public class TiredBehaviour : MonoBehaviour
{
    private GoapActionProvider actionProvider;
    public float value = 50;
    public bool IsTired => this.value >= 100;
    public bool AtRestroom;
    
    private void Awake()
    {
        this.value = Random.Range(0, 100f);
        this.actionProvider = this.GetComponent<GoapActionProvider>();
    }

    private void FixedUpdate()
    {
        if (this.actionProvider.Receiver.IsPaused)
            return;

        this.value += Time.fixedDeltaTime * 2f;
    }

    public void TakeRest(float value)
    {
        this.value -= value; 
    }
}