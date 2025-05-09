using UnityEngine;
using System.Collections.Generic;

public class MisturaComEspatula : MonoBehaviour
{
    public Transform espatula;
    public float limiteDeMovimento = 0.3f;
    public GameObject recheioProntoVisual;

    private List<GameObject> ingredientesVisuais = new List<GameObject>();

    private Vector3 ultimaPosicao;
    private float movimentoAcumulado = 0f;
    private bool misturaFinalizada = false;

    void Start()
    {
        if (espatula != null)
            ultimaPosicao = espatula.position;

        if (recheioProntoVisual != null)
            recheioProntoVisual.SetActive(false);
    }

    void Update()
    {
        if (misturaFinalizada || espatula == null) return;

        var tipo = GetComponentInParent<ReceitaRecheio>()?.receitaAtual ?? TipoReceita.Nenhuma;
        if (tipo != TipoReceita.Recheio) return;

        float deslocamento = Vector3.Distance(espatula.position, ultimaPosicao);
        ultimaPosicao = espatula.position;
        movimentoAcumulado += deslocamento;

        if (movimentoAcumulado >= limiteDeMovimento && TodosIngredientesPresentes())
        {
            FinalizarMistura();
        }
    }

    void FinalizarMistura()
    {
        misturaFinalizada = true;
        foreach (var ingrediente in ingredientesVisuais)
            if (ingrediente != null) Destroy(ingrediente);

        recheioProntoVisual?.SetActive(true);
        Debug.Log("Mistura do recheio finalizada!");
    }

    bool TodosIngredientesPresentes()
    {
        foreach (var ingrediente in ingredientesVisuais)
            if (ingrediente == null) return false;
        return true;
    }

    public void AdicionarIngredienteVisual(GameObject ingrediente)
    {
        if (!ingredientesVisuais.Contains(ingrediente))
            ingredientesVisuais.Add(ingrediente);
    }
}