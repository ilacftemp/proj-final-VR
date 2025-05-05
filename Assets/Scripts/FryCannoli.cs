using UnityEngine;

public class FryCannoli : MonoBehaviour
{
    public GameObject rawCannoli;          // Objeto cru (enrolado no cilindro)
    public GameObject cookedCannoli;       // Objeto pronto (frito)
    public float fryTime = 10f;            // Tempo de fritura
    public bool isOilHot = false;          // Controle de ativação
    private bool isFrying = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isOilHot || isFrying) return;

        if (other.gameObject == rawCannoli)
        {
            isFrying = true;
            StartCoroutine(Fry());
        }
    }

    private System.Collections.IEnumerator Fry()
    {
        yield return new WaitForSeconds(fryTime);

        rawCannoli.SetActive(false);
        cookedCannoli.SetActive(true);
        cookedCannoli.transform.position = rawCannoli.transform.position;

        isFrying = false;
    }
}
