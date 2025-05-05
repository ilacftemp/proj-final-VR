using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public Transform rightHandTransform;
    public Transform leftHandTransform;
    public XRController rightHandController;
    public XRController leftHandController;
    public InputHelpers.Button grabButton = InputHelpers.Button.Grip;
    public float activationThreshold = 0.1f;

    private bool rightHandInside = false;
    private bool leftHandInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            rightHandInside = true;
        }
        else if (other.CompareTag("LeftHand"))
        {
            leftHandInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            rightHandInside = false;
        }
        else if (other.CompareTag("LeftHand"))
        {
            leftHandInside = false;
        }
    }

    void Update()
    {
        if (rightHandInside && rightHandController)
        {
            InputHelpers.IsPressed(rightHandController.inputDevice, grabButton, out bool isPressed, activationThreshold);
            if (isPressed)
            {
                SpawnApple(rightHandTransform);
                rightHandInside = false;
            }
        }

        if (leftHandInside && leftHandController)
        {
            InputHelpers.IsPressed(leftHandController.inputDevice, grabButton, out bool isPressed, activationThreshold);
            if (isPressed)
            {
                SpawnApple(leftHandTransform);
                leftHandInside = false;
            }
        }
    }

    private void SpawnApple(Transform handTransform)
    {
        Instantiate(applePrefab, handTransform.position, handTransform.rotation, handTransform);
    }
}