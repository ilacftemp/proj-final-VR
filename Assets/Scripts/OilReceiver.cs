using UnityEngine;

public class OilReceiver : MonoBehaviour
{
    public Transform oilLevelObject; // cilindro que sobe
    public float fillSpeed = 0.01f;

    private bool isFilling = false;
    private Vector3 baseScale;
    private Vector3 basePosition;

    private void Start()
    {
        baseScale = oilLevelObject.localScale;
        basePosition = oilLevelObject.localPosition;

        // Garante que começa vazio, mas posicionado na base
        oilLevelObject.localScale = new Vector3(baseScale.x, 0f, baseScale.z);
        oilLevelObject.localPosition = basePosition;
    }

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
            float newY = scale.y + fillSpeed * Time.deltaTime;

            // Aplica nova escala Y
            oilLevelObject.localScale = new Vector3(scale.x, newY, scale.z);

            // Corrige a posição: move para cima metade da altura nova
            Vector3 pos = oilLevelObject.localPosition;
            oilLevelObject.localPosition = new Vector3(pos.x, newY * 0.5f, pos.z);
        }
    }

}
