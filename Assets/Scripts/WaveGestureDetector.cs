using UnityEngine;
using Oculus.Interaction; // For hand tracking

public class WaveGestureDetector : MonoBehaviour
{
    [SerializeField] private OVRHand rightHand; // Reference to the right hand (set in Inspector)

    private float handMovementThreshold = 0.02f; // Minimum movement to count as a wave
    private Vector3 previousRightHandPos; // To track previous right hand position

    public bool IsWaving { get; private set; } // Flag to indicate if the player is waving
    public bool IsPlayerNearMerchant { get; set; } // Flag to track if the player is near the merchant

    void Start()
    {
        // Initialize right hand position
        previousRightHandPos = rightHand.transform.position;
    }

    void Update()
    {
        // Only check for waving if the player is near the merchant
        if (IsPlayerNearMerchant)
        {
            // Detect wave movement for the right hand (with palm facing away from the player)
            if (IsHandWaving(rightHand, ref previousRightHandPos) && IsPalmFacingAway(rightHand))
            {
                IsWaving = true; // Player is waving
            }
            else
            {
                IsWaving = false; // Player is not waving
            }

            // Debug message when the player is waving
            if (IsWaving)
            {
                Debug.Log("Player is waving!"); // This will print when the player is waving
            }
        }
    }

    bool IsHandWaving(OVRHand hand, ref Vector3 previousPos)
    {
        Vector3 handMovement = hand.transform.position - previousPos;
        previousPos = hand.transform.position;

        // Simple check: if hand is moving side to side (with enough distance)
        return Mathf.Abs(handMovement.x) > handMovementThreshold && Mathf.Abs(handMovement.y) < handMovementThreshold;
    }

    // Check if the palm is facing away from the player
    bool IsPalmFacingAway(OVRHand hand)
    {
        // The hand's forward direction is along the palm
        Vector3 palmForward = hand.transform.forward;

        // Check if the palm is facing away from the player (roughly)
        Vector3 playerDirection = (hand.transform.position - Camera.main.transform.position).normalized;

        // Palm is facing away if the dot product between the palm's forward vector and the player's direction is negative
        return Vector3.Dot(palmForward, playerDirection) < 0;
    }
}
