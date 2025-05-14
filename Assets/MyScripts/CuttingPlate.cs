using UnityEngine;

public class CuttingPlate : MonoBehaviour
{
    public GameObject macaNaTábua;
    public GameObject massaNaTábua;

    private bool itemAtivado = false;

    void OnTriggerEnter(Collider other)
    {
        if (itemAtivado) return;

        if (other.CompareTag("Maca") && macaNaTábua != null)
        {
            macaNaTábua.SetActive(true);
            other.gameObject.SetActive(false);
            itemAtivado = true;
            Debug.Log("Maçã ativada na tábua.");
        }
        else if (other.CompareTag("Massa") && massaNaTábua != null)
        {
            massaNaTábua.SetActive(true);
            other.gameObject.SetActive(false);
            itemAtivado = true;
            Debug.Log("Massa ativada na tábua.");
        }
    }
}