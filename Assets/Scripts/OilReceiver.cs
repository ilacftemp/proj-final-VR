using UnityEngine;

public class OilReceiver : MonoBehaviour
{
    public Transform oilLevelObject; // cilindro que sobe
    public float fillSpeed = 0.01f;
    private bool isFilling = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("OilStream"))
        {
            isFilling = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OilStream"))
        {
            isFilling = false;
        }
    }

    private void Update()
    {
        if (isFilling)
        {
            Vector3 scale = oilLevelObject.localScale;
            scale.y += fillSpeed * Time.deltaTime;
            oilLevelObject.localScale = scale;
        }
    }
}
