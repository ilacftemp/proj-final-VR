using UnityEngine;

public class SpawnOnRemove : MonoBehaviour
{
    public GameObject prefabToSpawn; // O prefab que será monitorado e respawnado
    private GameObject currentInstance;
    private bool isRespawning = false;

    void Start()
    {
       // SpawnNew();
    }

    void Update()
    {
        // if (currentInstance == null && !isRespawning)
        // {
        //     isRespawning = true;
        //     
        // }
    }

    public void SpawnNew()
    {
        Debug.Log("SpawnNew called");
        currentInstance = Instantiate(prefabToSpawn, transform.position, transform.rotation, transform);
        isRespawning = false;
    }
    

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PileOfFlower"))
        {
            Invoke(nameof(SpawnNew), 0.5f); // pequena espera evita duplo spawn
            Debug.Log("Spawned new object: " + prefabToSpawn.name);
        }
    }
}
