using System.Collections.Generic;
using Helpers.TagSelector;
using UnityEngine;

namespace GOAP
{
    public class PatientsManager : MonoBehaviour
    {
        public static PatientsManager Instance { get; private set; }
        
        
        [SerializeField][TagSelector] private string patientTag;
        [SerializeField][TagSelector] private string spawnPointTag;
        
        private Transform spawnPoint;

        private Queue<Patient> patientsQueue = new();

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is already an instance of PatientsManager");
                
                return;
            }
            
            Instance = this;
            
            spawnPoint = GameObject.FindGameObjectWithTag(spawnPointTag).transform;

            RegisterAllExistencePatients();
        }

        private void RegisterAllExistencePatients()
        {
            GameObject[] patients = GameObject.FindGameObjectsWithTag(patientTag);

            if (patients.Length == 0)
            {
                Debug.LogError("No patients found on the scene");
                
                return;
            }

            foreach (var patient in patients)
            {
                AddPatient(patient.GetComponent<Patient>());
                
                Debug.Log($"Patient {patient.name} added to the queue");
            }
        }

        private void AddPatient(Patient patient)
        {
            patientsQueue.Enqueue(patient);
        }

        public Patient GetAndDeletePatient()
        {
            return HasPatients() ? patientsQueue.Dequeue() : null;
        }

        public bool HasPatients()
        {
            return patientsQueue.Count > 0;
        }
    }
}