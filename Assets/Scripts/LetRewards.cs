using System.Collections.Generic;
using UnityEngine;

public class LetRewards : MonoBehaviour
{
    public InventorySystem inventorySystem;
    private HashSet<char> availableLetters;  // Set of available letters to reward
    private int lettersPerTask = 3; // number of letters rewarded per task
    void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
        availableLetters = new HashSet<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
    }

    public void FinishedTask()
    {
        // find learned letters from inv
        HashSet<char> learnedLetters = inventorySystem.GetLearnedLetters();  

        // get not learned letters
        HashSet<char> remainingLetters = new HashSet<char>(availableLetters);
        remainingLetters.ExceptWith(learnedLetters);

        if (remainingLetters.Count == 0)
        {
            Debug.Log("No letters left to reward");
            return;
        }

        // randomize the remaining letters and pick a few
        List<char> lettersToReward = new List<char>(remainingLetters);
        int rewardCount = Mathf.Min(lettersPerTask, lettersToReward.Count);  

        // rng letter reward
        List<char> rewardedLetters = new List<char>();
        for (int i = 0; i < rewardCount; i++)
        {
            int randIndex = Random.Range(0, lettersToReward.Count);
            char letter = lettersToReward[randIndex];
            lettersToReward.RemoveAt(randIndex);  // no duplicates
            rewardedLetters.Add(letter);
        }

        foreach (char letter in rewardedLetters)
        {
            TranslateEvent evt = new()
            {
                OldWord = letter.ToString(),
                NewWord = letter.ToString()
            };

            // add the letter to the inventory
            inventorySystem.AddLetter(evt);

            EventManager.Broadcast(evt);
        }

        Debug.Log($"Task completed! Rewarded letters: {string.Join(", ", rewardedLetters)}");
    }
}
