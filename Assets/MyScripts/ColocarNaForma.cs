using UnityEngine;

public class ColocarNaForma : MonoBehaviour
{
    public GameObject formaMassaCrua;
    public string tagFormaVazia = "FormaVazia";

    private bool podeSerColocada = false;

    public void AtivarPegavel()
    {
        podeSerColocada = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!podeSerColocada) return;

        if (other.CompareTag(tagFormaVazia))
        {
            if (formaMassaCrua != null)
                formaMassaCrua.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}