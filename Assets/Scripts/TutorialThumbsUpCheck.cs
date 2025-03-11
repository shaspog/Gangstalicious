using UnityEngine;
using TMPro; // For tutorial UI
using Oculus.Interaction;

public class TutorialThumbsUpCheck : MonoBehaviour
{
    [SerializeField] private ActiveStateGroup _activeStateGroup;  // Reference to the ActiveStateGroup
    [SerializeField] private TextMeshProUGUI _tutorialText;       // Reference to the TextMeshPro for tutorial steps
    [SerializeField] private GameObject _thumbsUpIcon;            // Optional thumbs-up icon to show when gesture detected

    private int _tutorialStep = 0;  // To track the tutorial step

    private void Update()
    {
        // Check if the ActiveStateGroup's condition is met (i.e., thumbs-up gesture is active)
        if (_activeStateGroup != null && _activeStateGroup.Active)
        {
            OnThumbsUpDetected();
        }
    }

    private void OnThumbsUpDetected()
    {
        // Handle the detection of the thumbs-up gesture
        if (_thumbsUpIcon != null)
        {
            _thumbsUpIcon.SetActive(true);  // Show thumbs-up icon for feedback
        }

        // Proceed to the next step in the tutorial
        ProgressTutorial();
    }

    private void ProgressTutorial()
    {
        // Increment tutorial step
        _tutorialStep++;

        // Update the tutorial text based on the current step
        switch (_tutorialStep)
        {
            case 1:
                _tutorialText.text = "Well done! Now, try making the next gesture.";
                break;
            case 2:
                _tutorialText.text = "You're getting the hang of it! Keep going!";
                break;
            case 3:
                _tutorialText.text = "Tutorial complete! You're ready to proceed!";
                // Optionally, end or transition to the next scene/step
                break;
            default:
                _tutorialText.text = "Waiting for the thumbs-up gesture...";
                break;
        }
    }

    #region Inject

    // Method to inject dependencies (for testing purposes)
    public void InjectAllTutorialThumbsUpCheck(ActiveStateGroup activeStateGroup, TextMeshProUGUI tutorialText, GameObject thumbsUpIcon)
    {
        _activeStateGroup = activeStateGroup;
        _tutorialText = tutorialText;
        _thumbsUpIcon = thumbsUpIcon;
    }

    #endregion
}
