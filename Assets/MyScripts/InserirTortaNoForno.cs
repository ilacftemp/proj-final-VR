using UnityEngine;

public class InserirTortaNoForno : MonoBehaviour
{
    public GameObject portaAberta;
    public GameObject tortaNoForno;
    public string tagFormas = "Formas";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFormas) && portaAberta.activeSelf)
        {
            if (tortaNoForno != null)
                tortaNoForno.SetActive(true);
        }
    }
}