using UnityEngine;

public class StoveHeater : MonoBehaviour
{
    public GameObject smokeEffect;
    public GameObject panObject;
    public float heatTime = 10f;

    private bool panOnStove = false;
    private float heatTimer = 0f;

    public FryCannoli fryCannoliScript;

    void Update()
    {
        if (panOnStove)
        {
            heatTimer += Time.deltaTime;

            if (heatTimer >= heatTime && !smokeEffect.activeSelf)
            {
                if (smokeEffect != null) smokeEffect.SetActive(true);
                AtivarFritura();
            }
        }
    }

    void AtivarFritura()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == panObject)
        {
            panOnStove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == panObject)
        {
            panOnStove = false;
            heatTimer = 0f;

            if (smokeEffect != null)
                smokeEffect.SetActive(false);

        }
    }
}
