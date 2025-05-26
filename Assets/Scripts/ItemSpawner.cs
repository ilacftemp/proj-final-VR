using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    public string tagDoItem = "Item";
    private bool temItemDentro = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagDoItem))
            temItemDentro = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagDoItem))
            temItemDentro = false;
    }

    void Update()
    {
        if (!temItemDentro)
        {
            GameObject novoItem = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, transform);
            temItemDentro = true;
        }
    }
}
