using UnityEngine;

public class PanDetector : MonoBehaviour
{
    public GameObject PanelaOriginal;
    public GameObject PanObject;
    public GameObject PoofEffect;

    public FryCannoli fryCannoliScript; // Referência ao script FryCannoli

    private void Start()
    {
        PanObject.SetActive(false);

        if (fryCannoliScript != null)
            fryCannoliScript.enabled = false; // Desativa no início
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Panela"))
        {
            PanObject.SetActive(true);
            Debug.Log("Panela detectada! Objeto ativado.");
            Instantiate(PoofEffect, transform.position, Quaternion.identity);
            Destroy(PanelaOriginal);

            if (fryCannoliScript != null)
                fryCannoliScript.enabled = true; // Ativa o script de fritar
        }
    }
}
