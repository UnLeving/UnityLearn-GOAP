using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace GOAP
{
    [GoapId("PatientTargetSensor")]
    public class PatientTargetSensor : LocalTargetSensorBase
    {
        public override ISensorTimer Timer { get; } = SensorTimer.Interval(.5f);

        public override void Created()
        { 
            
        }

        public override void Update()
        {
            
        }

        public override ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget)
        {
            var nurse = references.GetCachedComponent<Nurse>();

            if (nurse != null && nurse.HasPatient)
            {
                return existingTarget;
            }
            
            var patient = PatientsManager.Instance.GetPatient();
            
            if (patient == null) return null;
            
            nurse.HasPatient = true;

            if (existingTarget is TransformTarget transformTarget)
            {
                return transformTarget.SetTransform(patient.transform);
            }
            
            return new TransformTarget(patient.transform);
        }
    }
}