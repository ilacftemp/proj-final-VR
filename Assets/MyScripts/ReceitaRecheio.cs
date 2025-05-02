using UnityEngine;
using System.Collections.Generic;

public class ReceitaRecheio : MonoBehaviour
{
    private readonly HashSet<string> ingredientesNecessarios = new HashSet<string>
    {
        "FatiasMaca",
        "Canela",
        "Manteiga",
        "Acucar"
    };

    private HashSet<string> ingredientesRecebidos = new HashSet<string>();

    [System.Serializable]
    public class IngredienteVisual
    {
        public string tag;
        public GameObject visualPrefab;
        public Vector3 localPosition;
    }

    public List<IngredienteVisual> visuaisDosIngredientes;

    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (ingredientesNecessarios.Contains(tag) && !ingredientesRecebidos.Contains(tag))
        {
            ingredientesRecebidos.Add(tag);

            // GameManager.instance.AdicionarPontos(10); // opcional
            Destroy(other.gameObject);

            foreach (var ingrediente in visuaisDosIngredientes)
            {
                if (ingrediente.tag == tag)
                {
                    GameObject visual = Instantiate(ingrediente.visualPrefab, transform);
                    visual.transform.localPosition = ingrediente.localPosition;

                    var mistura = GetComponentInChildren<MisturaComEspatula>();
                    if (mistura != null)
                    {
                        mistura.AdicionarIngredienteVisual(visual);
                    }

                    break;
                }
            }
        }
    }
}
