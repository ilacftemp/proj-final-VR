using UnityEngine;
using System.Collections.Generic;

public class MisturaComFouet : MonoBehaviour
{
    public Transform fouet;
    public float movimentoEstagio1 = 0.3f;
    public float movimentoEstagio2 = 0.6f;
    public GameObject massaMisturadaVisual;
    public GameObject massaHomogeneaVisual;

    private ReceitaRecheio receita;
    private Vector3 ultimaPosicao;
    private float movimentoAcumulado = 0f;
    private int estagio = 0;

    void Start()
    {
        if (fouet != null) ultimaPosicao = fouet.position;
        massaMisturadaVisual?.SetActive(false);
        massaHomogeneaVisual?.SetActive(false);
        receita = GetComponentInParent<ReceitaRecheio>();
    }

    void Update()
    {
        if (receita == null || receita.receitaAtual != TipoReceita.Massa || fouet == null || estagio == 2) return;

        float deslocamento = Vector3.Distance(fouet.position, ultimaPosicao);
        ultimaPosicao = fouet.position;
        movimentoAcumulado += deslocamento;

        if (!receita.TodosIngredientesAdicionados()) return;

        if (movimentoAcumulado >= movimentoEstagio2 && estagio == 1)
        {
            estagio = 2;
            foreach (var ing in receita.GetIngredientesVisuais())
                Destroy(ing);
            massaMisturadaVisual?.SetActive(false);
            massaHomogeneaVisual?.SetActive(true);
            Debug.Log("Massa homogênea pronta!");
        }
        else if (movimentoAcumulado >= movimentoEstagio1 && estagio == 0)
        {
            estagio = 1;
            massaMisturadaVisual?.SetActive(true);
            Debug.Log("Massa parcialmente misturada.");
        }
    }
}