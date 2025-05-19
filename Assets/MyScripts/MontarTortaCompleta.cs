using UnityEngine;

public class MontarTortaCompleta : MonoBehaviour
{
    public string nomeTortaComRecheio = "torta_crua_com_recheio";

    public string nomeRawPie = "raw_pie";

    public string tagTortaComRecheio = "TortaComRecheio";

    private GameObject tortaComRecheio;
    private GameObject rawPie;

    private void Start()
    {
        tortaComRecheio = GameObject.Find(nomeTortaComRecheio);
        rawPie = GameObject.Find(nomeRawPie);

        if (tortaComRecheio == null)
            Debug.LogWarning("Não encontrei 'tortaComRecheio'. Verifique o nome ou tag.");

        if (rawPie == null)
            Debug.LogWarning("Não encontrei 'rawPie'. Verifique o nome ou tag.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagTortaComRecheio))
        {
            if (tortaComRecheio != null) tortaComRecheio.SetActive(false);
            if (rawPie != null) rawPie.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}