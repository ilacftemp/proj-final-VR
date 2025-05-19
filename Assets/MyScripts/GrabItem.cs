using UnityEngine;
using UnityEngine.InputSystem;


public class GrabItem : MonoBehaviour
{
    public GameObject itemToSpawn;
    public InputActionProperty leftTriggerAction;
    public InputActionProperty rightTriggerAction;
    public Transform leftHandTransform;
    public Transform rightHandTransform;

    private bool leftHandInside = false;
    private bool rightHandInside = false;

    void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter" + other.name);
        if (other.CompareTag("LeftHand")) leftHandInside = true;
        print("mao esquerda " + leftHandInside);
        if (other.CompareTag("RightHand")) rightHandInside = true;
        print("mao direita " + rightHandInside);
    }

    void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("LeftHand")) leftHandInside = false;
       if (other.CompareTag("RightHand")) rightHandInside = false;
    }

    void Update()
    {
        if (leftHandInside && leftTriggerAction.action.WasPressedThisFrame())
        {
            print("Left Trigger Pressed");
            SpawnInHand(leftHandTransform);
        }

        if (rightHandInside && rightTriggerAction.action.WasPressedThisFrame())
        {
            print("Right Trigger Pressed");
            SpawnInHand(rightHandTransform);
        }
    }

    void SpawnInHand(Transform hand)
    {
        print("Spawning item in hand");
        GameObject spawned = Instantiate(itemToSpawn, hand.position, hand.rotation);
        //spawned.transform.SetParent(hand);

        //Grab the item on the hand (Controller)
        var interactor = hand.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor>();
        if (interactor != null)
        {
            var interactable = spawned.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (interactable != null)
            {
                //interactor.StartManualInteraction(interactable);
            }
        } 
    }
}