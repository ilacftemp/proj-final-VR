using UnityEngine;

public class CuttingPlate : MonoBehaviour
{
    public GameObject macaNaTábua;
    public GameObject macaNaMaoDoPlayer;

    private bool macaAtivada = false;

    void OnTriggerEnter(Collider other)
    {
        if (!macaAtivada && other.CompareTag("Maca"))
        {
            macaNaTábua?.SetActive(true);
            other.gameObject.SetActive(false);
            macaAtivada = true;
            Debug.Log("Maçã ativada na tábua.");
        }
    }
}