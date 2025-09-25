using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject patientPrefab;
    [SerializeField] private int spawnCount = 10;
    [SerializeField] private bool loop;

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(patientPrefab, transform.position, Quaternion.identity);
        }

        Invoke(nameof(SpawnPatient), 25);
    }

    private void SpawnPatient()
    {
        if (loop)
            Instantiate(patientPrefab, transform.position, Quaternion.identity);

        Invoke(nameof(SpawnPatient), Random.Range(2, 10));
    }
}