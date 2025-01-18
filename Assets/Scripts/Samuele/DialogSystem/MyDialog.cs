using System.Collections;
using TMPro;
using UnityEngine;

public class MyDialog : MonoBehaviour
{
    [Header("NPC Dialog")]
    [SerializeField][Multiline()] private string[] dialogLines;
    [SerializeField] private TMP_Text dialogBox;

    [Header("Gesture to understand")]
    [SerializeField] private GameObject gesture;

    // Variables for the dialogue system
    private bool isAlreadyTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        // EventManager.AddListener<TranslateEvent>(TranslateMessage);
        EventManager.TranslateEvent += TranslateMessage;
       
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartDialog()
    {
        if (!isAlreadyTalking)
        {
            isAlreadyTalking = true;
            StartCoroutine(TalkToPlayer());
        }
    }

    private IEnumerator TalkToPlayer()
    {
        if (dialogLines.Length == 0)
        {
            Debug.Log("What do I have to say?");
            yield break;
        }

        GetRightGesture();

        foreach (var line in dialogLines)
        {
            var charArray = line.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                dialogBox.text += charArray[i];
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(2);
            
            dialogBox.text = "";
        }

        isAlreadyTalking = false;
    }

    private void GetRightGesture()
    {
        // Check if gestures are right for this NPC

        EventManager.FireRewardEvent(Random.Range(0, TranslationManager.GetWordsToTranslate().Count - 1));
    }

    private void TranslateMessage(string oldWord, string newWord)
    {
        for (int i = 0; i < dialogLines.Length; i++)
        {
            var newDialog = dialogLines[i].Replace(oldWord, newWord);
            dialogLines[i] = newDialog;
        }
    }

}
