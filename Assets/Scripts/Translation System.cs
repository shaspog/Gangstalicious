using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationSystem : MonoBehaviour
{
    [SerializeField]
    private Font customSymbols;
    [SerializeField]
    private Font normalText;

    private HashSet<char> learnedLetters = new HashSet<char>(); //tracker collected letters

    private string sentence = "Danke!"; //example sentence to translate

    public string TranslateSentence(string input)
    {
        char[] translated = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char letter = char.ToUpper(input[i]);
            if (char.IsLetter(letter) && !learnedLetters.Contains(letter))
            {
                //translate unknown letters/symbols with placeholders
                translated[i] = '?'; //placeholder
            }
            else
            {
                translated[i] = input[i]; //keep known lett's
            }
        }

        return new string(translated); 
    }

    public void LearnLetter(char letter)
    {
        letter = char.ToUpper(letter);
        if (!learnedLetters.Contains(letter))
        {
            learnedLetters.Add(letter);
            Debug.Log($"learned: {letter}");
        }
    }

    public void DisplayTranslations()
    {
        string translated = TranslateSentence(sentence);
        Debug.Log($"Original: {sentence}");
        Debug.Log($"translated: {translated}");
    }
}
