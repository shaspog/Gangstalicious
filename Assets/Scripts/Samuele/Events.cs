// The Game Events used across the Game.
// Anytime there is a need for a new event, it should be added here.

public static class Events
{
    public static TranslateEvent TranslateEvent = new();
}

public class TranslateEvent : GameEvent
{
    public string OldWord;
    public string NewWord;
}