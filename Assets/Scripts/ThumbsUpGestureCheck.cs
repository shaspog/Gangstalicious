using UnityEngine;
using Oculus.Interaction;

public class ThumbsUpGestureCheck : MonoBehaviour
{
    // ActiveStateGroup components for both hands (thumbs-up detection)
    [SerializeField] private ActiveStateGroup thumbsUpRightActiveState;  // Reference to ActiveStateGroup for right hand thumbs-up
    [SerializeField] private ActiveStateGroup thumbsUpLeftActiveState;   // Reference to ActiveStateGroup for left hand thumbs-up

    // ActiveStateGroup for the right hand pinch gesture
    [SerializeField] private ActiveStateGroup pinchRightActiveState; // Pinch detection for the right hand

    // ActiveStateGroup for the right hand peace gesture
    [SerializeField] private ActiveStateGroup peaceRightActiveState; // Peace detection for the right hand

    // Flags to track if gestures have been detected
    public bool IsThumbsUpDetected { get; private set; }
    public bool IsPinchDetected { get; private set; }
    public bool IsPeaceDetected { get; private set; }

    void Update()
    {
        // Check for thumbs-up gesture
        CheckThumbsUpGesture();

        // Check for pinch gesture
        CheckPinchGesture();

        // Check for peace gesture
        CheckPeaceGesture();
    }

    void CheckThumbsUpGesture()
    {
        // Check if both the right and left hands are making a thumbs-up gesture
        bool rightThumbsUp = thumbsUpRightActiveState.Active;
        bool leftThumbsUp = thumbsUpLeftActiveState.Active;

        // If both hands are making a thumbs-up, set the flag to true
        if (rightThumbsUp && leftThumbsUp)
        {
            IsThumbsUpDetected = true;
        }
        else
        {
            IsThumbsUpDetected = false;
        }
    }

    void CheckPinchGesture()
    {
        // Check if the right hand is performing the pinch gesture
        bool rightPinch = pinchRightActiveState.Active;

        // If the right hand is performing the pinch, set the flag to true
        if (rightPinch)
        {
            IsPinchDetected = true;
        }
        else
        {
            IsPinchDetected = false;
        }
    }

    void CheckPeaceGesture()
    {
        // Check if the right hand is performing the peace gesture
        bool rightPeace = peaceRightActiveState.Active;

        // If the right hand is performing the peace, set the flag to true
        if (rightPeace)
        {
            IsPeaceDetected = true;
        }
        else
        {
            IsPeaceDetected = false;
        }
    }
}
