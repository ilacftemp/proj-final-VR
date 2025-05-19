using UnityEngine;

public class SpawnOnRemove : MonoBehaviour
{
    public GameObject prefabToSpawn; // O prefab que será monitorado e respawnado
    private GameObject currentInstance;
    private bool isRespawning = false;

    void Start()
    {
        SpawnNew();
    }

    void Update()
    {
        if (currentInstance == null && !isRespawning)
        {
            isRespawning = true;
            Invoke(nameof(SpawnNew), 0.1f); // pequena espera evita duplo spawn
        }
    }

    void SpawnNew()
    {
        currentInstance = Instantiate(prefabToSpawn, transform.position, transform.rotation, transform);
        isRespawning = false;
    }
}
