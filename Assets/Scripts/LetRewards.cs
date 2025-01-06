using System.Collections.Generic;
using UnityEngine;

public class LetRewards : MonoBehaviour
{
    private List<string> availableWords;
    // private int lettersPerTask;

    void Start()
    {
        // availableWords = TranslationManager.GetAvailableWords();
        // lettersPerTask = availableWords.Count / 3; //Divide by number of tasks
    }

    public void FinishedTask()
    {
        if (TranslationManager.GetTranslatedWords().Count <= 0)  return;

        // if (availableWords.Count == 0)
        // {
        //     Debug.Log("no letters left to reward");
        //     return;
        // }    

        // //randomzier
        // var taskWords = availableWords
        //     .OrderBy(x => Random.value)
        //     .Take(lettersPerTask)
        //     .ToList();

        // foreach (var word in taskWords)
        // {
        //     availableWords.Remove(word); //remove learned letters
        // }

        // foreach (var word in taskWords)
        // {
        //     AddWordToInventory evt = new()
        //     {
        //         Word = word
        //     };
        //     EventManager.Broadcast(evt);
        // }

        var randIndex = Random.Range(0, TranslationManager.GetTranslatedWords().Count);

        TranslateEvent evt = new()
        {
            OldWord = TranslationManager.GetWordsToTranslate()[randIndex],
            NewWord = TranslationManager.GetTranslatedWords()[randIndex]
        };
        EventManager.Broadcast(evt);

        // Debug.Log($"task done rewards: {string.Join(",", taskWords)}");
    }
}
