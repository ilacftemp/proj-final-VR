using UnityEngine;

public class OilPourer : MonoBehaviour
{
    public Transform pourPoint;         // Ponto de onde o óleo começa (no bico)
    public Transform oilStream;         // Cilindro que representa o fio de óleo
    public float pourAngleThreshold = 100f;
    public float maxStreamLength = 1.0f;
    public float growSpeed = 1.5f;

    private float currentLength = 0f;

    void Start()
    {
        oilStream.localScale = new Vector3(oilStream.localScale.x, 0f, oilStream.localScale.z);
        oilStream.localPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        float tilt = Vector3.Angle(transform.up, Vector3.up);

        if (tilt > pourAngleThreshold)
        {
            if (currentLength < maxStreamLength)
            {
                currentLength += growSpeed * Time.deltaTime;
                float newYScale = currentLength / 2f;
                oilStream.localScale = new Vector3(oilStream.localScale.x, newYScale, oilStream.localScale.z);
                oilStream.localPosition = new Vector3(0f, -newYScale, 0f);
            }
        }
        else
        {
            if (currentLength > 0f)
            {
                currentLength -= growSpeed * Time.deltaTime;
                currentLength = Mathf.Max(currentLength, 0f);
                float newYScale = currentLength / 2f;
                oilStream.localScale = new Vector3(oilStream.localScale.x, newYScale, oilStream.localScale.z);
                oilStream.localPosition = new Vector3(0f, -newYScale, 0f);
            }
        }
    }
}
