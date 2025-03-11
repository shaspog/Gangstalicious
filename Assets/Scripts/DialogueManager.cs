using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement; // To load the next scene

public class DialogueManager : MonoBehaviour
{
    private bool isMerchantApproached = false; // Flag to check if the merchant has been approached
    private bool isPlayerNearMerchant = false; // Flag to check if the player is near the merchant

    public WaveGestureDetector waveGestureDetector; // Reference to the wave gesture detector script
    public ThumbsUpGestureCheck thumbsUpGestureCheck; // Corrected reference to ThumbsUpGestureCheck script
    public ThumbsUpGestureCheck pinchGestureCheck; // Reference to pinch gesture check
    public ThumbsUpGestureCheck peaceGestureCheck; // Reference to peace gesture check

    public string greetingMessage = "H**l*!"; // Initial greeting message
    public string waveMessage = "W**l* yo* lik* a ho**d*g?"; // Message when the player waves
    public string thumbsUpMessage = "G**d, i* w**l t*k* j*s* a se***nd*."; // Message when the thumbs-up gesture is detected
    public string nextMessage = "H*r* y** *o! I* wi** b* 6.00"; // Message after 15 seconds pause
    public string pinchMessage = "T*n** y*u!"; // Message when the pinch gesture is detected
    public string peaceMessage = "P*c* an* *ove!"; // Message when the peace gesture is detected

    // Reference to the TextMeshPro UI Text element for dialogue display
    public TMP_Text dialogueText;

    private bool thumbsUpDetected = false; // Flag to track if thumbs-up gesture is detected
    private bool pinchDetected = false; // Flag to track if pinch gesture is detected
    private bool peaceDetected = false; // Flag to track if peace gesture is detected

    // When the player enters the trigger zone (near the merchant)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player triggers the collider
        {
            isPlayerNearMerchant = true;
            waveGestureDetector.IsPlayerNearMerchant = true; // Set player near merchant in WaveGestureDetector
            UpdateDialogue(greetingMessage); // Display initial greeting
            isMerchantApproached = false; // Reset merchant approach status
        }
    }

    // When the player leaves the trigger zone (moving away from the merchant)
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearMerchant = false;
            waveGestureDetector.IsPlayerNearMerchant = false; // Reset when player leaves
            UpdateDialogue(""); // Clear dialogue when the player leaves the merchant's range
            isMerchantApproached = false; // Reset when player leaves
        }
    }

    void Update()
    {
        // Only check for waving if the player is near the merchant and hasn't already approached
        if (isPlayerNearMerchant && !isMerchantApproached && waveGestureDetector.IsWaving)
        {
            StartMerchantDialogue(); // Start the dialogue if the player is waving
        }

        // Check if thumbs-up gesture has been detected after the wave message
        if (isMerchantApproached && !thumbsUpDetected && thumbsUpGestureCheck.IsThumbsUpDetected)
        {
            ContinueMerchantDialogue(); // Continue dialogue after thumbs-up gesture
        }

        // Check if pinch gesture has been detected after the next message
        if (isMerchantApproached && !pinchDetected && pinchGestureCheck.IsPinchDetected)
        {
            DisplayPinchMessage(); // Show pinch message after pinch gesture is detected
        }

        // Check if peace gesture has been detected after the pinch message
        if (pinchDetected && !peaceDetected && peaceGestureCheck.IsPeaceDetected)
        {
            DisplayPeaceMessage(); // Show peace message after peace gesture is detected
        }

        // Check if the last message (peace message) has been displayed and wait 3 seconds before loading the tutorial scene
        if (peaceDetected)
        {
            StartCoroutine(WaitAndLoadTutorialScene());
        }
    }

    void StartMerchantDialogue()
    {
        // Set the flag to true once the merchant has been approached (waved at)
        isMerchantApproached = true;
        UpdateDialogue(waveMessage); // Display the second message when the player waves
    }

    void ContinueMerchantDialogue()
    {
        // Display the thumbs-up message and set the thumbs-up flag
        thumbsUpDetected = true;
        UpdateDialogue(thumbsUpMessage); // Display the message after thumbs-up gesture is detected

        // Start the coroutine to wait for 15 seconds before continuing dialogue
        StartCoroutine(WaitAndContinueDialogue());
    }

    IEnumerator WaitAndContinueDialogue()
    {
        // Wait for 15 seconds before displaying the next message
        yield return new WaitForSeconds(15f);

        // Update the dialogue with the next message
        UpdateDialogue(nextMessage);
    }

    void DisplayPinchMessage()
    {
        // Display the pinch message and set the pinch flag
        pinchDetected = true;
        UpdateDialogue(pinchMessage); // Display the message after pinch gesture is detected
    }

    void DisplayPeaceMessage()
    {
        // Display the peace message and set the peace flag
        peaceDetected = true;
        UpdateDialogue(peaceMessage); // Display the message after peace gesture is detected
    }

    IEnumerator WaitAndLoadTutorialScene()
    {
        // Wait for 3 seconds after the last message before transitioning to the tutorial scene
        yield return new WaitForSeconds(5f);

        // Load the "Tutorial" scene
        SceneManager.LoadScene("Tutorial");
    }

    void UpdateDialogue(string message)
    {
        if (dialogueText != null) // Check if dialogueText is assigned
        {
            dialogueText.text = message; // Update the dialogue text on the UI
        }
    }
}
