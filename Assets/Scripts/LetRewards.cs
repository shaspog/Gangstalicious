using System.Collections.Generic;
using UnityEngine;

public class LetRewards : MonoBehaviour
{
    private List<string> availableWords;
    // private int lettersPerTask;

    private string oldWord;
    private string newWord;

    void Start()
    {
        // availableWords = TranslationManager.GetAvailableWords();
        // lettersPerTask = availableWords.Count / 3; //Divide by number of tasks
    }

    public void FinishedTask()
    {
        if (TranslationManager.GetAvailableWords().Count <= 0)  return;

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

        TranslateEvent evt = new()
        {
            OldWord = oldWord,
            NewWord = newWord
        };
        EventManager.Broadcast(evt);

        // Debug.Log($"task done rewards: {string.Join(",", taskWords)}");
    }
}
