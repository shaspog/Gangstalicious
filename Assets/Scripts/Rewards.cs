using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewards : MonoBehaviour
{
    public LetRewards letRewards; //reference to the letter manager

    public void FinishedTask()
    {
        if (letRewards != null)
        {
            letRewards.FinishedTask();
        }

        else
        {
            Debug.LogError("No letManager present");
        }
    }
}
