using UnityEngine;

public class OilDetector : MonoBehaviour
{
    public GameObject oilVisual; // O cilindro que aparece quando tem óleo
    public float oilFillTime = 2f; // Tempo necessário para ativar (em segundos)
    private float oilTimer = 0f;
    private bool filled = false;

    void OnParticleCollision(GameObject other)
    {
        if (filled) return;

        oilTimer += Time.deltaTime;

        if (oilTimer >= oilFillTime)
        {
            oilVisual.SetActive(true);
            filled = true;
        }
    }
}
