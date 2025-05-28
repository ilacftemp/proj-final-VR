using UnityEngine;

public class DoughMolder : MonoBehaviour
{
    public GameObject flatDough;       // Massa achatada
    public GameObject moldedDough;     // Massa moldada (cannoli)
    public GameObject poofEffect;      // Prefab do efeito com som e partículas

    private void Start()
    {
        // Certifique-se de que o objeto de massa moldada esteja desativado no início
        moldedDough.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        // Debug.Log("DoughMolder OnTriggerEnter: " + other.name);


        if (other.CompareTag("FlatDough"))
        {
            Destroy(flatDough);

            moldedDough.SetActive(true);
            Instantiate(poofEffect, transform.position, Quaternion.identity);
            Debug.Log("Massa moldada com sucesso!");
        }
    }
}
