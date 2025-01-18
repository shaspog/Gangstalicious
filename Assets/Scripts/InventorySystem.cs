using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI noteText; // ref for notebook
    [SerializeField] private char unknownSymbol = '?';

    private HashSet<char> learnedLetters = new();
    private string currentAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    void Start()
    {
        EventManager.TranslateEvent += AddLetter;
        // EventManager.AddListener<TranslateEvent>(AddLetter);
        UpdateNoteDisplay();
    }

    // add letters to the notebook
    public void AddLetter(string oldWord, string newWord)
    {
        foreach (char letter in newWord.ToUpper())
        {
            learnedLetters.Add(letter);
            Debug.Log($"Learned new letter: {letter}"); // replace with UI pop in future
        }
        UpdateNoteDisplay();
    }

    // update notebook with learned letters
    public void UpdateNoteDisplay()
    {
        string displayText = $"Learned letters:\n";

        foreach (char letter in currentAlphabet)
        {
            if (learnedLetters.Contains(letter))
            {
                displayText += $"{letter}";
            }
            else
            {
                displayText += $"{unknownSymbol}";
            }
        }
        // noteText.text = displayText.Trim();
    }

    // methdo to find learned letters
    public HashSet<char> GetLearnedLetters()
    {
        return learnedLetters;
    }

    // method to translate message based on learned letters
    public string TranslateMessage(string message)
    {
        char[] translatedMessage = new char[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            char currentChar = message[i];

            if (learnedLetters.Contains(char.ToUpper(currentChar)))
            {
                translatedMessage[i] = currentChar;
            }
            else if (char.IsWhiteSpace(currentChar) || char.IsPunctuation(currentChar))
            {
                translatedMessage[i] = currentChar;
            }
            else
            {
                translatedMessage[i] = unknownSymbol;
            }
        }
        return new string(translatedMessage);
    }
}
