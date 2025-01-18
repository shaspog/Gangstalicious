using UnityEngine;
using UnityEngine.Events;

// A simple Event System that can be used for remote systems communication
public class EventManager : MonoBehaviour
{
    // Game Events
    public static UnityAction<string, string> TranslateEvent;
    public static UnityAction<int> RewardEvent;

    // Fire translation event
    // parameters are the word to translate and its translation
    public static void FireTranslateEvent(string oldWord, string newWord)
    {
        TranslateEvent?.Invoke(oldWord, newWord);
    }

    // Fire reward event
    // parameter is index for the translation list
    public static void FireRewardEvent(int index)
    {
        RewardEvent?.Invoke(index);
    }
}