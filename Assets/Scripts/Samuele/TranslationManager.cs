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
    private List<string> wordsTranslated = new(){
        "hello",
        "thank",
        "left",
        "right",
        "morning",
        "evening",
    };

    public static List<string> GetWordsToTranslate()
    {
        return wordsToTranslate;
    }

    void Start()
    {
        EventManager.RewardEvent += WordTranslated;
    }

    private void WordTranslated(int index)
    {
        var oldWord = wordsToTranslate[index];
        var newWord = wordsTranslated[index];

        EventManager.FireTranslateEvent(oldWord, newWord);

        wordsToTranslate.Remove(wordsToTranslate[index]);
        wordsTranslated.Remove(wordsTranslated[index]);
    }
}