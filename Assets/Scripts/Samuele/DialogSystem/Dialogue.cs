using System.Collections;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("SO Dialogues")]
    [SerializeField] private SODialogue[] dialogues;
    
    [Header("Writing data")]
    [SerializeField][Range(0.01f, 1.0f)] private float waitType = 0.01f;
    
    private int dialogueIndex = 0;

    private bool wait = false;
    private bool isTalking = false;
    private bool isStoppedTalking = false;

    void OnValidate()
    {
        if (dialogues == null || dialogues.Length == 0)  return;

        if (dialogues[0].needsPrevious)
        {
            Debug.LogWarning("Thats the wrong one my guy");
            dialogues[0] = null;
            return;
        }
        
        for (int i = 1; i < dialogues.Length - 1; i++)
            if (!dialogues[i].needsPrevious)
            {
                Debug.LogWarning("Thats the wrong one my guy");
                dialogues[i] = null;
            }
    }

    void Update()
    {
        if (!wait && !isTalking)
            StartCoroutine(CheckForDialogue());
    }

    private IEnumerator CheckForDialogue()
    {
        wait = true;
        
        if (Physics.SphereCast(transform.position, 10, Vector3.zero, out RaycastHit hitInfo))
            if (hitInfo.collider.CompareTag("Player"))
                StartDialogue();
        
        yield return new WaitForSeconds(0.05f);
        wait = false;
    }

    void StartDialogue()
    {
        if (!isStoppedTalking)
        {
            isTalking = true;
            StartCoroutine(TypeLine());
        }
    }

    private IEnumerator TypeLine()
    {
        foreach (string lines in dialogues[dialogueIndex].lines)
        {
            foreach(char c in lines.ToCharArray())
            {
                yield return new WaitForSeconds(waitType);
            }
        }

        if (!dialogues[dialogueIndex].needsAnswer)
            NextLine();
        // else
            // Do Wait for the answer
    }

    void NextLine()
    {
        if (dialogueIndex < dialogues.Length - 1)
            dialogueIndex++;
        else
            StartCoroutine(StopTalking());
    }

    IEnumerator StopTalking()
    {
        isStoppedTalking = true;

        yield return new WaitForSeconds(5);

        isStoppedTalking = false;
    }

    void Restart()
    {
        dialogueIndex = 0;
        isTalking = false;
        StopCoroutine(TypeLine());
    }
}
