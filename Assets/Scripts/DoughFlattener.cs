using UnityEngine;

public class DoughFlattener : MonoBehaviour
{
    public GameObject doughObject;       
    public GameObject flatDoughObject;  
    public GameObject poofEffect;        

    private bool hasDough = false;
    private bool hasRollingPin = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dough"))
        {
            hasDough = true;
        }

        if (other.CompareTag("RollingPin"))
        {
            hasRollingPin = true;
        }

        if (hasDough && hasRollingPin)
        {
            FlattenDough();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dough"))
        {
            hasDough = false;
        }

        if (other.CompareTag("RollingPin"))
        {
            hasRollingPin = false;
        }
    }

    void FlattenDough()
    {
        if (poofEffect != null && doughObject != null)
        {
            Vector3 spawnPosition = doughObject.transform.position + Vector3.up * 0.05f;
            GameObject effect = Instantiate(poofEffect, spawnPosition, Quaternion.identity);
            Destroy(effect, 2f); // destrói após 2 segundos
        }

        doughObject.SetActive(false);
        flatDoughObject.SetActive(true);
    }
}
