using UnityEngine;

public class MassaController : MonoBehaviour
{
    [SerializeField] private GameObject massaGrande;
    [SerializeField] private GameObject massaPequena1;
    [SerializeField] private GameObject massaPequena2;

    private bool cortada = false;

    void Start()
    {
        massaGrande?.SetActive(true);
        massaPequena1?.SetActive(false);
        massaPequena2?.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (cortada) return;
        if (!other.CompareTag("Faca")) return;

        massaGrande?.SetActive(false);
        massaPequena1?.SetActive(true);
        massaPequena2?.SetActive(true);
        cortada = true;
        Debug.Log("Massa cortada em duas partes.");
    }
}