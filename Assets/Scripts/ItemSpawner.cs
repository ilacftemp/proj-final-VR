using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemSpawner : MonoBehaviour
{
    public GameObject riceBallPrefab;
    public Transform spawnPoint;
    private bool hasSpawned = false;


    private bool handInside = false;
    private XRController currentController;

    void OnTriggerEnter(Collider other)
    {
        UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor interactor = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor>();
        if (interactor != null)
        {
            currentController = other.GetComponentInParent<XRController>();
            handInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor interactor = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor>();
        if (interactor != null)
        {
            currentController = null;
            handInside = false;
        }
    }

    void Update()
    {
        if (handInside && currentController != null &&
            currentController.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerPressed))
        {
            if (triggerPressed && !hasSpawned)
            {
                SpawnRiceBall();
                hasSpawned = true;
            }
            else if (!triggerPressed)
            {
                hasSpawned = false; 
            }
        }
    }
    void SpawnRiceBall()
    {
        if (riceBallPrefab != null && spawnPoint != null)
        {
            Instantiate(riceBallPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
