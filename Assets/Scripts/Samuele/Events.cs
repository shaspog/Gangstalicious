// The Game Events used across the Game.
// Anytime there is a need for a new event, it should be added here.

public static class Events
{
    public static AddWordToInventory AddWordToInventory = new();
    public static TranslateEvent TranslateEvent = new();
}

public class AddWordToInventory : GameEvent
{
    public string Word;
}

public class TranslateEvent : GameEvent
{
    public string OldWord;
    public string NewWord;
}