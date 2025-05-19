using UnityEngine;

public class ColocarRecheioNaForma : MonoBehaviour
{
    [Tooltip("Nome exato do GameObject da torta com recheio já posicionada na cena")]
    public string nomeFormaComRecheio = "torta_crua_com_recheio";

    [Tooltip("Tag que identifica a forma que já contém a massa crua")]
    public string tagFormaComMassa = "FormaComMassa";

    private GameObject formaTortaCruaComRecheio;

    private void Start()
    {
        // Tenta encontrar automaticamente o objeto pelo nome
        formaTortaCruaComRecheio = GameObject.Find(nomeFormaComRecheio);
        if (formaTortaCruaComRecheio == null)
        {
            Debug.LogWarning("Objeto 'TortaCruaComRecheio' não encontrado na cena. Verifique o nome no Inspector ou na hierarquia.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFormaComMassa))
        {
            if (formaTortaCruaComRecheio != null)
                formaTortaCruaComRecheio.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}