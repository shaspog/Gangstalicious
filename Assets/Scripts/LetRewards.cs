using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LetRewards : MonoBehaviour
{
    public InventorySystem letInventory;
    private List<char> availableLetters;
    private int lettersPerTask;

    void Start()
    {
        availableLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();
        lettersPerTask = availableLetters.Count / 3; //Divide by number of tasks
    }

    public void FinishedTask()
    {
        if (availableLetters.Count == 0)
        {
            Debug.Log("no letters left to reward");
            return;
        }    

        //randomzier
        var taskLetters = availableLetters
            .OrderBy(x => Random.value)
            .Take(lettersPerTask)
            .ToList();

        foreach (var letter in taskLetters)
        {
            availableLetters.Remove(letter); //remove learned letters
        }

        foreach (var letter in taskLetters)
        {
            letInventory.AddLetter(letter); //add to the inv
        }

        Debug.Log($"task done rewards: {string.Join(",", taskLetters)}");
    }
}
