using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public enum TipoReceita { Nenhuma, Massa, Recheio }

public class ReceitaRecheio : MonoBehaviour
{
    private readonly HashSet<string> ingredientesMassa = new HashSet<string> { "Agua", "Farinha", "Manteiga", "Acucar" };
    private readonly HashSet<string> ingredientesRecheio = new HashSet<string> { "FatiasMaca", "Canela", "Manteiga", "Acucar" };

    public TipoReceita receitaAtual { get; private set; } = TipoReceita.Nenhuma;
    private HashSet<string> ingredientesRecebidos = new HashSet<string>();

    private Dictionary<string, (GameObject prefab, Vector3 localPos)> mapaDeVisuais;

    [Header("Referências para os prefabs")]
    public GameObject prefabFatiasMaca;
    public GameObject prefabCanela;
    public GameObject prefabManteiga;
    public GameObject prefabAcucar;
    public GameObject prefabAgua;
    public GameObject prefabFarinha;

    void Start()
    {
        mapaDeVisuais = new Dictionary<string, (GameObject, Vector3)> {
            { "FatiasMaca", (prefabFatiasMaca, new Vector3(-0.0244f, 0.0319f, 0f)) },
            { "Canela", (prefabCanela, new Vector3(0.6891f, 0.0514f, 0.2802f)) },
            { "Manteiga", (prefabManteiga, new Vector3(0.7184f, 0.0463f, 0.2602f)) },
            { "Acucar", (prefabAcucar, new Vector3(0.6636f, 0.0558f, 0.2535f)) },
            { "Agua", (prefabAgua, new Vector3(0.5f, 0.05f, 0.25f)) },
            { "Farinha", (prefabFarinha, new Vector3(0.6f, 0.05f, 0.27f)) }
        };
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (!PertenceAAlgumaReceita(tag) || ingredientesRecebidos.Contains(tag)) return;

        if (receitaAtual == TipoReceita.Nenhuma)
        {
            ingredientesRecebidos.Add(tag);
            AdicionarVisual(tag, other.gameObject);

            bool podeSerMassa = ingredientesRecebidos.All(i => ingredientesMassa.Contains(i));
            bool podeSerRecheio = ingredientesRecebidos.All(i => ingredientesRecheio.Contains(i));

            if (podeSerMassa && !podeSerRecheio)
                receitaAtual = TipoReceita.Massa;
            else if (podeSerRecheio && !podeSerMassa)
                receitaAtual = TipoReceita.Recheio;
        }
        else
        {
            bool pertence = receitaAtual == TipoReceita.Massa ? ingredientesMassa.Contains(tag) : ingredientesRecheio.Contains(tag);
            if (!pertence) return;

            ingredientesRecebidos.Add(tag);
            AdicionarVisual(tag, other.gameObject);
        }
    }

    bool PertenceAAlgumaReceita(string tag)
    {
        return ingredientesMassa.Contains(tag) || ingredientesRecheio.Contains(tag);
    }

    void AdicionarVisual(string tag, GameObject obj)
    {
        Destroy(obj);

        if (!mapaDeVisuais.ContainsKey(tag)) return;

        var (prefab, localPos) = mapaDeVisuais[tag];
        GameObject visual = Instantiate(prefab, transform);
        visual.transform.localPosition = localPos;

        GetComponentInChildren<MisturaComEspatula>()?.AdicionarIngredienteVisual(visual);
        GetComponentInChildren<MisturaComFouet>()?.AdicionarIngredienteVisual(visual);
    }
}