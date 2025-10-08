using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace GOAP
{
    public class PatientBrain : MonoBehaviour
    {
        private GoapActionProvider provider;

        private void Awake()
        {
            this.provider = this.GetComponent<GoapActionProvider>();
        }

        private void Start()
        {
            this.provider.RequestGoal<GetCuredGoal>(true);
        }
    }
}