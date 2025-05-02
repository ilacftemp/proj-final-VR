using UnityEngine;
using System.Collections.Generic;

public class MisturaComEspatula : MonoBehaviour
{
    public Transform espatula;
    public float limiteDeMovimento = 0.3f;
    public GameObject recheioProntoVisual;

    [Tooltip("Lista de ingredientes visuais que vão sumir após misturar.")]
    public List<GameObject> ingredientesVisuais = new List<GameObject>();

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
        {
            if (ingrediente != null)
                Destroy(ingrediente);
        }

        if (recheioProntoVisual != null)
            recheioProntoVisual.SetActive(true);

        Debug.Log("Mistura finalizada. Ingredientes sumiram, recheio pronto ativo.");
    }

    bool TodosIngredientesPresentes()
    {
        foreach (var ingrediente in ingredientesVisuais)
        {
            if (ingrediente == null) return false;
        }
        return true;
    }

    public void AdicionarIngredienteVisual(GameObject ingrediente)
    {
        if (!ingredientesVisuais.Contains(ingrediente))
            ingredientesVisuais.Add(ingrediente);
    }
}