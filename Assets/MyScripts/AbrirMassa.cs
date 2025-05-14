using UnityEngine;

public class AbrirMassa : MonoBehaviour
{
    [SerializeField] private GameObject massaDividida;

    private bool aberta = false;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (aberta) return;
        if (!other.CompareTag("Rolo")) return;

        if (massaDividida != null && massaDividida.activeInHierarchy)
        {
            massaDividida.SetActive(false);
            gameObject.SetActive(true);
            aberta = true;

            Debug.Log($"{name}: massa aberta com o rolo.");
        }
    }
}