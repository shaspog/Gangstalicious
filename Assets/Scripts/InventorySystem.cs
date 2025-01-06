using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI noteText; // Reference to display on the notebook
    private List<string> learnedWords = new(); // List that stores new words

    void Start()
    {
        EventManager.AddListener<TranslateEvent>(AddWord);
    }

    // Function that adds words to inventory
    private void AddWord(TranslateEvent evt)
    {
        if (!learnedWords.Contains(evt.NewWord))
        {
            learnedWords.Add(evt.NewWord);
            UpdateNoteDisplay(); // Refresh notebook to reflect new findings
            Debug.Log($"New word: {evt.NewWord}");
        }
        else
        {
            Debug.Log($"Word '{evt.NewWord}' is already in inv");
        }
    }

    // Function to update the notebook display
    public void UpdateNoteDisplay()
    {
        string displayText = string.Join(", ", learnedWords);
        noteText.text = $"Learned letters:\n{displayText}";
    }

    public List<string> GetLearnedWords()
    {
        return learnedWords;
    }
}
