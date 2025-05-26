using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public enum TipoReceita { Nenhuma, Massa, Recheio }

public class ReceitaRecheio : MonoBehaviour
{
    public TipoReceita receitaAtual { get; private set; } = TipoReceita.Nenhuma;

    private HashSet<string> ingredientesMassa = new HashSet<string> { "Agua", "Farinha", "Manteiga", "Acucar" };
    private HashSet<string> ingredientesRecheio = new HashSet<string> { "FatiasMaca", "Canela", "Manteiga", "Acucar" };
    private HashSet<string> ingredientesRecebidos = new HashSet<string>();

    private Dictionary<string, GameObject> mapaDeVisuais;

    void Start()
    {
        mapaDeVisuais = new Dictionary<string, GameObject>
        {
            { "FatiasMaca", transform.Find("fatias")?.gameObject },
            { "Canela", transform.Find("canela")?.gameObject },
            { "Manteiga", transform.Find("manteiga")?.gameObject },
            { "Acucar", transform.Find("acucar")?.gameObject },
            { "Agua", transform.Find("agua")?.gameObject },
            { "Farinha", transform.Find("farinha")?.gameObject }
        };

        foreach (var go in mapaDeVisuais.Values)
            if (go != null) go.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if ((!ingredientesMassa.Contains(tag)) && (!ingredientesRecheio.Contains(tag))) return;
        if (ingredientesRecebidos.Contains(tag)) return;

        ingredientesRecebidos.Add(tag);

        if (receitaAtual == TipoReceita.Nenhuma)
        {
            bool podeSerMassa = ingredientesRecebidos.All(i => ingredientesMassa.Contains(i));
            bool podeSerRecheio = ingredientesRecebidos.All(i => ingredientesRecheio.Contains(i));

            if (podeSerMassa && !podeSerRecheio) receitaAtual = TipoReceita.Massa;
            else if (podeSerRecheio && !podeSerMassa) receitaAtual = TipoReceita.Recheio;
            else return;
        }

        MostrarVisual(tag);
    }

    void MostrarVisual(string tag)
    {
        if (mapaDeVisuais.TryGetValue(tag, out var go)) go?.SetActive(true);
    }

    public bool TodosIngredientesAdicionados()
    {
        if (receitaAtual == TipoReceita.Massa)
            return ingredientesMassa.SetEquals(ingredientesRecebidos);
        else if (receitaAtual == TipoReceita.Recheio)
            return ingredientesRecheio.SetEquals(ingredientesRecebidos);
        return false;
    }

    public IEnumerable<GameObject> GetIngredientesVisuais()
    {
        return ingredientesRecebidos.Select(tag => mapaDeVisuais.TryGetValue(tag, out var go) ? go : null).Where(go => go != null);
    }
}