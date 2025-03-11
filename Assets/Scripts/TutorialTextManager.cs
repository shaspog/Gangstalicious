using System.Collections;
using UnityEngine;
using TMPro; // Only if you're using TextMeshPro

public class TutorialTextManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText; // Drag your UI text object here in the inspector

    void Start()
    {
        tutorialText.text = "Welcome to the tutorial!";
        StartCoroutine(SwitchTextAfterDelay());
    }

    IEnumerator SwitchTextAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        tutorialText.text = "Do a thumbs up with both of your hands to begin!";
    }
}
