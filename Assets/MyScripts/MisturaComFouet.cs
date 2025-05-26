using UnityEngine;
using System.Collections.Generic;

public class MisturaComFouet : MonoBehaviour
{
    public Transform fouet;
    public float tempoParaEstagio1 = 2f;
    public float tempoParaEstagio2 = 5f;
    public GameObject massaMisturadaVisual;
    public GameObject massaHomogeneaVisual;

    private ReceitaRecheio receita;
    private float tempoContato = 0f;
    private int estagio = 0;
    private bool fouetEmContato = false;

    void Start()
    {
        massaMisturadaVisual?.SetActive(false);
        massaHomogeneaVisual?.SetActive(false);
        receita = GetComponentInParent<ReceitaRecheio>();
    }

    void Update()
    {
        if (receita == null || receita.receitaAtual != TipoReceita.Massa || estagio == 2) return;
        if (!receita.TodosIngredientesAdicionados()) return;

        if (fouetEmContato)
        {
            tempoContato += Time.deltaTime;

            if (tempoContato >= tempoParaEstagio2 && estagio == 1)
            {
                estagio = 2;
                foreach (var ing in receita.GetIngredientesVisuais())
                    Destroy(ing);
                massaMisturadaVisual?.SetActive(false);
                massaHomogeneaVisual?.SetActive(true);
                Debug.Log("Massa homogênea pronta!");
            }
            else if (tempoContato >= tempoParaEstagio1 && estagio == 0)
            {
                estagio = 1;
                massaMisturadaVisual?.SetActive(true);
                Debug.Log("Massa parcialmente misturada.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == fouet)
            fouetEmContato = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == fouet)
            fouetEmContato = false;
    }
}