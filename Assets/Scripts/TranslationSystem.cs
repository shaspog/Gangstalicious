/*
using System.Collections.Generic;
using UnityEngine;

public class TranslationSystem : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public char unknownSymbol = '?';        

    public string TranslateMessage(string message)
    {
        List<string> knownLetters = inventorySystem.GetLearnedLetters();
        char[] translatedMessage = new char[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            char currentChar = message[i];

            if (knownLetters.Contains(currentChar))
            {
                translatedMessage[i] = currentChar; // keeps the learned letters
            }
            else if (char.IsWhiteSpace(currentChar) || char.IsPunctuation(currentChar))
            {
                translatedMessage[i] = currentChar; //gramma check
            }
            else
            {
                translatedMessage[i] = unknownSymbol; // replace unknown with known symbol for the unknown
            }
        }
        return new string(translatedMessage);
    }
}
*/