using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private List<char> collectedLetters = new List<char>(); // List that stores new letters

    //function that adds letters to inv
    public void AddLetter(char letter)
    {
        if (!collectedLetters.Contains(letter))
        {
            collectedLetters.Add(letter);
            Debug.Log($"New letter: {letter}");
        }
        
        else
        {
            Debug.Log($"Letter '{letter}' is already in inv");
        }
    }

    public void DisplayInventory()
    {
        string inventoryContent = "Collected Letters: ";
        foreach (char letter in collectedLetters)
        {
            inventoryContent += $"{letter}";
        }
        Debug.Log(inventoryContent);
    }


}
