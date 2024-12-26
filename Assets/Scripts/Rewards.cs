using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewards : MonoBehaviour
{
    public InventorySystem letterInventory; //ref to inv
    public char rewardLetter; // what letter is given as a reward. Change later into a list?? multiple letters

    public void CompleteTask()
    {
        if (letterInventory != null)
        {
            letterInventory.AddLetter(rewardLetter);
            Debug.Log($"Task finished: {rewardLetter}");
        }
    }
}
