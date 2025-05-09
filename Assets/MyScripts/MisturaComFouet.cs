using UnityEngine;
using System.Collections.Generic;

public class MisturaComFouet : MonoBehaviour
{
    public Transform fouet;
    public float movimentoEstagio1 = 0.3f;
    public float movimentoEstagio2 = 0.6f;
    public GameObject massaMisturadaVisual;
    public GameObject massaHomogeneaVisual;

    public List<GameObject> ingredientesVisuais = new List<GameObject>();

    private Vector3 ultimaPosicao;
    private float movimentoAcumulado = 0f;
    private int estagio = 0;

    void Start()
    {
        if (fouet != null)
            ultimaPosicao = fouet.position;

        massaMisturadaVisual?.SetActive(false);
        massaHomogeneaVisual?.SetActive(false);
    }

    void Update()
    {
        var tipo = GetComponentInParent<ReceitaRecheio>()?.receitaAtual ?? TipoReceita.Nenhuma;
        if (tipo != TipoReceita.Massa || fouet == null || estagio == 2) return;

        float deslocamento = Vector3.Distance(fouet.position, ultimaPosicao);
        ultimaPosicao = fouet.position;
        movimentoAcumulado += deslocamento;

        if (TodosIngredientesPresentes())
        {
            if (movimentoAcumulado >= movimentoEstagio2 && estagio == 1)
                FinalizarEstagio2();
            else if (movimentoAcumulado >= movimentoEstagio1 && estagio == 0)
                FinalizarEstagio1();
        }
    }

    void FinalizarEstagio1()
    {
        estagio = 1;
        massaMisturadaVisual?.SetActive(true);
        Debug.Log("Estágio 1: Massa parcialmente misturada.");
    }

    void FinalizarEstagio2()
    {
        estagio = 2;
        foreach (var ingrediente in ingredientesVisuais)
            if (ingrediente != null) Destroy(ingrediente);

        massaMisturadaVisual?.SetActive(false);
        massaHomogeneaVisual?.SetActive(true);
        Debug.Log("Estágio 2: Massa homogênea pronta.");
    }

    bool TodosIngredientesPresentes()
    {
        foreach (var i in ingredientesVisuais)
            if (i == null) return false;
        return true;
    }

    public void AdicionarIngredienteVisual(GameObject ingrediente)
    {
        if (!ingredientesVisuais.Contains(ingrediente))
            ingredientesVisuais.Add(ingrediente);
    }
}