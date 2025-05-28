using UnityEngine;
using System.Collections;

public class FryCannoli : MonoBehaviour
{
    public GameObject rawCannoli;         // Cannoli cru
    public GameObject cookedCannoli;      // Cannoli frito

    public GameObject DoneCannoli;
    public GameObject poofEffect;         // Efeito de fritura
    public float fryTime = 10f;           // Tempo de fritura


    private void Start()
    {
        cookedCannoli.SetActive(false); // Garante que o frito começa desativado
        DoneCannoli.SetActive(false);   // Garante que o cannoli pronto começa desativado
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Cannoli"))
        {
            Debug.Log("Cannoli detected, starting to fry...");

            // Destroy(rawCannoli);          // Esconde o cru
            rawCannoli.SetActive(false);    // Esconde o cru
            cookedCannoli.SetActive(true);
            StartCoroutine(FryProcess());
        }
    }

    private IEnumerator FryProcess()
    {
        yield return new WaitForSeconds(fryTime);

        // Mostra poof
        Instantiate(poofEffect, rawCannoli.transform.position, Quaternion.identity);

        // Troca visual
        // Mostra o frito
        Debug.Log("Cannoli is ready!");

        DoneCannoli.SetActive(true);
        cookedCannoli.SetActive(false); // Esconde o frito
        
        
    }
}
