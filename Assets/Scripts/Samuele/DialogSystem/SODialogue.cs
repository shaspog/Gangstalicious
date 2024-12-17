using UnityEngine;

[CreateAssetMenu(fileName="Dialogue Lines", menuName="ScriptableObjects/Dyalogue system", order = 1)]
public class SODialogue : ScriptableObject
{
    [Header("Dialog lines")]
    [Multiline()]
    public string[] lines;

    [Header("Check if needs an answer")]
    public bool needsAnswer;
    [Header("Check if needs previous dialog")]
    public bool needsPrevious;
    
    [Header("Your answers for this lines")]
    public string[] answers;
}
