using UnityEngine;
using System.Collections;

public class BowlIngredientReceiver : MonoBehaviour
{
    public GameObject butterVisual;
    public GameObject flourVisual;
    public GameObject sugarVisual;
    public GameObject massaVisual;
    public GameObject mixingUI; // <- Adiciona aqui o GameObject da imagem no canvas

    private int ingredientCount = 0;
    private bool isMixing = false;

    private void Start()
    {
        butterVisual.SetActive(false);
        flourVisual.SetActive(false);
        sugarVisual.SetActive(false);
        massaVisual.SetActive(false);
        mixingUI.SetActive(false); // <- Esconde a imagem da UI no início
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Manteiga"))
        {
            butterVisual.SetActive(true);
            ingredientCount++;
            Debug.Log("Manteiga recebida!");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Farinha"))
        {
            flourVisual.SetActive(true);
            ingredientCount++;
            Debug.Log("Farinha recebida!");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Acucar"))
        {
            sugarVisual.SetActive(true);
            ingredientCount++;
            Debug.Log("Açúcar recebido!");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Fue") && ingredientCount >= 3 && !isMixing)
        {
            Debug.Log("Todos os ingredientes recebidos! Misturando...");
            isMixing = true;
            StartCoroutine(Misturar());
        }
    }

    IEnumerator Misturar()
    {
        mixingUI.SetActive(true); // Mostra a imagem da mistura no Canvas

        yield return new WaitForSeconds(5f); // espera 5 segundos

        mixingUI.SetActive(false); // Esconde a imagem
        Debug.Log("Massa pronta!");

        massaVisual.SetActive(true);
        butterVisual.SetActive(false);
        flourVisual.SetActive(false);
        sugarVisual.SetActive(false);
    }
}
