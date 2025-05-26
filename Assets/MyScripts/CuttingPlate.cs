using UnityEngine;

public class CuttingPlate : MonoBehaviour
{
    public GameObject macaNaTábua;
    public GameObject massaNaTábua;
    public bool MassaFatiadaSaiu = false;
    public bool MassaDivididaSaiu = false;

    private bool itemAtivado = false;

    void Start()
    {
        macaNaTábua.SetActive(false);
        massaNaTábua.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entrou no gatilho: " + other.gameObject.name);
        if (itemAtivado) return;

        if (other.CompareTag("Maca") && macaNaTábua != null)
        {
            Destroy(other.gameObject); // remove a maçã externa
            macaNaTábua.SetActive(true); // ativa a maçã fixa da tábua
            itemAtivado = true;
            Debug.Log("Maçã ativada na tábua.");
        }

        if (other.CompareTag("Massa") && massaNaTábua != null)
        {
            Destroy(other.gameObject); // remove massa externa
            massaNaTábua.SetActive(true); // ativa massa fixa da tábua
            itemAtivado = true;
            Debug.Log("Massa ativada na tábua.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FatiasMaca") && macaNaTábua != null)
        {
            macaNaTábua.SetActive(false);
            itemAtivado = false;
            Debug.Log("Maçã desativada na tábua.");
        }
        else if (other.CompareTag("MassaFatiada") && massaNaTábua != null)
        {
            MassaFatiadaSaiu = true;
            if (MassaDivididaSaiu)
            {
                itemAtivado = false;
                Debug.Log("Massas desativadas na tábua.");
            }
        }
        else if (other.CompareTag("MassaDividida") && massaNaTábua != null)
        {
            MassaDivididaSaiu = true;
            if (MassaFatiadaSaiu)
            {
                itemAtivado = false;
                Debug.Log("Massas desativadas na tábua.");
            }
        }

        if (MassaDivididaSaiu && MassaFatiadaSaiu)
        {
            itemAtivado = false;
            Debug.Log("Massas desativadas na tábua.");
        }
    }
}
