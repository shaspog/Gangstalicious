using TMPro;
using UnityEngine;
using Oculus.Interaction;
using UnityEngine.SceneManagement; // For loading scenes

public class ThumbsUpTutorial : MonoBehaviour
{
    // TMP Text component to display the message
    [SerializeField] private TMP_Text tutorialText;

    // ActiveStateGroup components for both hands
    [SerializeField] private ActiveStateGroup thumbsUpRightActiveState;  // Reference to ActiveStateGroup component for right hand
    [SerializeField] private ActiveStateGroup thumbsUpLeftActiveState;   // Reference to ActiveStateGroup component for left hand
    [SerializeField] private ActiveStateGroup peaceSignRightActiveState;  // Reference for the right hand peace sign
    [SerializeField] private ActiveStateGroup peaceSignLeftActiveState;   // Reference for the left hand peace sign

    // Movement script to check if the player has started moving
    [SerializeField] private ArmSwingMovement armSwingMovement;

    // Check if both thumbs are up
    private bool rightThumbsUp = false;
    private bool leftThumbsUp = false;

    // Check if both hands are making a peace sign
    private bool rightPeaceSign = false;
    private bool leftPeaceSign = false;

    // Timing variables
    private float timeElapsed = 0f;
    private bool isThumbsUpCompleted = false;
    private bool isPlayerMoving = false;
    private bool isFirstMovement = false;
    private float moveMessageTime = 0f;

    void Start()
    {
        // Initialize states and start with the welcome message
        UpdateTutorialText("Welcome to 'Lost in Translation'");

        // Start the timer
        timeElapsed = 0f;
        moveMessageTime = 0f;
    }

    void Update()
    {
        // Check for the thumbs-up gesture
        if (!isThumbsUpCompleted)
        {
            timeElapsed += Time.deltaTime;

            // After 5 seconds, show the thumbs-up message
            if (timeElapsed >= 5f)
            {
                UpdateTutorialText("Do a thumbs up with both of your hands to start the tutorial!");
            }
        }

        // If the thumbs-up gesture has been completed, check for player movement
        if (isThumbsUpCompleted && !isPlayerMoving)
        {
            CheckPlayerMovement();
        }

        // If the player has moved and it is their first movement, show "Good job!" after a delay
        if (isPlayerMoving && !isFirstMovement)
        {
            moveMessageTime += Time.deltaTime;

            // After 5 seconds of moving, show the next message
            if (moveMessageTime >= 5f)
            {
                UpdateTutorialText("Good job!");
                isFirstMovement = true; // Mark that the first movement has been detected
            }
        }

        // If the first movement is detected, show the next message after 5 seconds
        if (isFirstMovement)
        {
            moveMessageTime += Time.deltaTime;

            // Show the next message after 5 more seconds
            if (moveMessageTime >= 10f) // 5 seconds after "Good job!"
            {
                UpdateTutorialText("Do a peace sign with both of your hands to start the game!");
            }
        }

        // Check if both thumbs are up
        CheckThumbsUp();

        // Check if both hands are making a peace sign
        CheckPeaceSign();
    }

    void CheckThumbsUp()
    {
        // Check if the right hand has made the thumbs up gesture
        rightThumbsUp = thumbsUpRightActiveState.Active;

        // Check if the left hand has made the thumbs up gesture
        leftThumbsUp = thumbsUpLeftActiveState.Active;

        // If both hands are making a thumbs up, update the text and move to the next step
        if (rightThumbsUp && leftThumbsUp && !isThumbsUpCompleted)
        {
            isThumbsUpCompleted = true;
            UpdateTutorialText("Swing your hands side by side to move around!");
        }
    }

    void CheckPlayerMovement()
    {
        // Check if the player has moved based on the armSwingMovement script
        if (armSwingMovement != null && armSwingMovement.HasMoved)
        {
            isPlayerMoving = true;
            UpdateTutorialText("Good job!"); // This will be displayed once player starts moving
        }
    }

    void CheckPeaceSign()
    {
        // Check if both hands are making a peace sign gesture
        rightPeaceSign = peaceSignRightActiveState.Active;
        leftPeaceSign = peaceSignLeftActiveState.Active;

        // If both hands are making a peace sign, load the main scene
        if (rightPeaceSign && leftPeaceSign)
        {
            UpdateTutorialText("Loading the game...");

            // Wait a moment to show the message before transitioning to the main scene
            Invoke("LoadMainScene", 2f);  // You can change the 2 seconds if needed
        }
    }

    void LoadMainScene()
    {

        SceneManager.LoadScene("Main"); 
    }

    void UpdateTutorialText(string message)
    {
        // Update the TMP text field with the new message
        if (tutorialText != null)
        {
            tutorialText.text = message;
        }
        else
        {
            Debug.LogError("TMP_Text reference is missing.");
        }
    }
}
