using UnityEngine;

public class ArmSwingMovement : MonoBehaviour
{
    public OVRHand leftHand, rightHand; // Assign in inspector
    public float moveSpeed = 2.5f;      // Speed of movement
    public float swingThreshold = 0.02f; // Minimum required movement to register a swing

    private Vector3 prevLeftPos, prevRightPos;
    private Transform headset; // Reference to the camera (headset)

    // Boolean to track if the player has moved
    public bool HasMoved { get; private set; }

    void Start()
    {
        // Store initial positions
        prevLeftPos = leftHand.transform.position;
        prevRightPos = rightHand.transform.position;

        // Get the main camera (which represents the player's headset)
        headset = Camera.main.transform;

        // Initialize HasMoved to false
        HasMoved = false;
    }

    void Update()
    {
        // Calculate vertical movement (swing) for each hand
        float leftHandSwing = leftHand.transform.position.y - prevLeftPos.y;
        float rightHandSwing = rightHand.transform.position.y - prevRightPos.y;

        // Check if hands are swinging in opposite directions (mimicking walking)
        if (Mathf.Abs(leftHandSwing) > swingThreshold && Mathf.Abs(rightHandSwing) > swingThreshold)
        {
            if ((leftHandSwing > 0 && rightHandSwing < 0) || (leftHandSwing < 0 && rightHandSwing > 0))
            {
                // Move in the direction the headset is facing
                Vector3 moveDirection = headset.forward;
                moveDirection.y = 0; // Keep movement on a flat plane

                transform.position += moveDirection * moveSpeed * Time.deltaTime;

                // Player has moved at least once
                if (!HasMoved)
                {
                    HasMoved = true;
                }
            }
        }

        // Update previous hand positions
        prevLeftPos = leftHand.transform.position;
        prevRightPos = rightHand.transform.position;
    }
}
