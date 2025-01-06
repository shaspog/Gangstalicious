using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public TextMeshProUGUI noteText; // Reference to display on the notebook
    private List<char> learnedLetters = new List<char>(); // List that stores new letters

    // Function that adds letters to inventory
    public void AddLetter(char letter)
    {
        if (!learnedLetters.Contains(letter))
        {
            learnedLetters.Add(letter);
            UpdateNoteDisplay(); // Refresh notebook to reflect new findings
            Debug.Log($"New letter: {letter}");
        }
        else
        {
            Debug.Log($"Letter '{letter}' is already in inv");
        }
    }

    // Function to update the notebook display
    public void UpdateNoteDisplay()
    {
        string displayText = string.Join(", ", learnedLetters);
        noteText.text = $"Learned letters:\n{displayText}";
    }

    public List<char> GetLearnedLetters()
    {
        return learnedLetters;
    }
}
