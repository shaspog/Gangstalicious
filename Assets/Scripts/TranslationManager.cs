using System.Collections.Generic;
using UnityEngine;

public class TranslationManager : MonoBehaviour
{
    // Those are the words that can be translated during the game,
    // make sure that both pairs are in the correct order.
    private static List<string> wordsToTranslate = new(){
        "ciao",
        "grazie",
        "sinistra",
        "destra",
        "giorno",
        "sera",
    };
    private static List<string> wordsTranslated = new(){
        "hello",
        "thank",
        "left",
        "right",
        "morning",
        "evening",
    };

    public static List<string> GetAvailableWords()
    {
        return wordsTranslated;
    }

    void Start()
    {
        
    }
}