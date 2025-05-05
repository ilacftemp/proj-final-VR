using UnityEngine;

public class DoughMolder : MonoBehaviour
{
    public GameObject flatDough;     // massa achatada
    public GameObject moldedDough;   // massa enrolada (cannoli)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlatDough"))
        {
            flatDough.SetActive(false);
            moldedDough.SetActive(true);
        }
    }
}
