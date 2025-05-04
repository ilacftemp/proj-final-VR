using UnityEngine;

public class DoughFlattener : MonoBehaviour
{
    public GameObject doughObject;        // Massa original
    public GameObject flatDoughObject;    // Massa achatada

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
        doughObject.SetActive(false);
        flatDoughObject.SetActive(true);
    }
}
