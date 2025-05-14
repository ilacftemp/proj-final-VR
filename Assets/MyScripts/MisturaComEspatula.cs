using UnityEngine;
using System.Collections.Generic;

public class MisturaComEspatula : MonoBehaviour
{
    public Transform espatula;
    public float limiteDeMovimento = 0.3f;
    public GameObject recheioProntoVisual;

    private Vector3 ultimaPosicao;
    private float movimentoAcumulado = 0f;
    private bool misturaFinalizada = false;
    private ReceitaRecheio receita;

    void Start()
    {
        if (espatula != null) ultimaPosicao = espatula.position;
        if (recheioProntoVisual != null) recheioProntoVisual.SetActive(false);
        receita = GetComponentInParent<ReceitaRecheio>();
    }

    void Update()
    {
        if (misturaFinalizada || receita == null || receita.receitaAtual != TipoReceita.Recheio) return;

        float deslocamento = Vector3.Distance(espatula.position, ultimaPosicao);
        ultimaPosicao = espatula.position;
        movimentoAcumulado += deslocamento;

        if (movimentoAcumulado >= limiteDeMovimento && receita.TodosIngredientesAdicionados())
        {
            misturaFinalizada = true;
            foreach (var ing in receita.GetIngredientesVisuais())
                Destroy(ing);
            recheioProntoVisual?.SetActive(true);
            Debug.Log("Recheio pronto!");
        }
    }
}