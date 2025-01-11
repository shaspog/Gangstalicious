using UnityEngine;

public class ThumbsUpGesture : MonoBehaviour
{
    [Header("Hand References")]
    public OVRHand leftHand;  // Assign LeftOVRHand here
    public OVRHand rightHand; // Assign RightOVRHand here

    [Header("Target Object to Change Color")]
    public Renderer targetObjectRenderer; // Assign the object's Renderer here
    public Color thumbsUpColor = Color.green; // Color when thumbs-up is detected
    public Color defaultColor = Color.white; // Default color

    void Update()
    {
        // Check for a thumbs-up gesture on the left hand
        if (leftHand != null && leftHand.IsTracked && IsThumbsUp(leftHand))
        {
            Debug.Log("Left hand is giving a thumbs-up!");
            ChangeObjectColor(thumbsUpColor);
        }
        // Check for a thumbs-up gesture on the right hand
        else if (rightHand != null && rightHand.IsTracked && IsThumbsUp(rightHand))
        {
            Debug.Log("Right hand is giving a thumbs-up!");
            ChangeObjectColor(thumbsUpColor);
        }
        else
        {
            // If no thumbs-up is detected, set to default color
            ChangeObjectColor(defaultColor);
        }
    }

    private bool IsThumbsUp(OVRHand hand)
    {
        // Check the thumb and other fingers
        bool isThumbExtended = hand.GetFingerConfidence(OVRHand.HandFinger.Thumb) == OVRHand.TrackingConfidence.High;
        bool areOtherFingersRelaxed = hand.GetFingerConfidence(OVRHand.HandFinger.Index) != OVRHand.TrackingConfidence.High &&
                                      hand.GetFingerConfidence(OVRHand.HandFinger.Middle) != OVRHand.TrackingConfidence.High &&
                                      hand.GetFingerConfidence(OVRHand.HandFinger.Ring) != OVRHand.TrackingConfidence.High &&
                                      hand.GetFingerConfidence(OVRHand.HandFinger.Pinky) != OVRHand.TrackingConfidence.High;

        return isThumbExtended && areOtherFingersRelaxed;
    }

    // Function to change the color of the target object
    private void ChangeObjectColor(Color newColor)
    {
        if (targetObjectRenderer != null)
        {
            targetObjectRenderer.material.color = newColor;
        }
    }
}
