using UnityEngine;

public class FatiarMaca3Etapas : MonoBehaviour
{
    [SerializeField] private GameObject visualInteira;   // Food_Apple (6)
    [SerializeField] private GameObject visualCortada;   // Food_Apple_Chopped
    [SerializeField] private GameObject visualFatias;    // Slices

    private int etapa = 0;

    void Start()
    {
        visualInteira?.SetActive(true);
        visualCortada?.SetActive(false);
        visualFatias?.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Faca")) return;

        switch (etapa)
        {
            case 0:
                visualInteira?.SetActive(false);
                visualCortada?.SetActive(true);
                etapa = 1;
                Debug.Log("Etapa 1: maçã cortada.");
                break;

            case 1:
                visualCortada?.SetActive(false);
                visualFatias?.SetActive(true);
                etapa = 2;
                Debug.Log("Etapa 2: maçã fatiada.");
                break;
        }
    }
}