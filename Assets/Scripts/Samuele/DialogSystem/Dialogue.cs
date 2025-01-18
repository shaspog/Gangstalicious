// using System.Collections;
// using System.Linq;
// using UnityEngine;

// public class Dialogue : MonoBehaviour
// {
//     [Header("SO Dialogues")]
//     [SerializeField] private SODialogue[] dialogues;
    
//     [Header("Writing data")]
//     [SerializeField][Range(0.01f, 1.0f)] private float waitType = 0.01f;
    
//     private int dialogueIndex = 0;

//     private bool wait = false;
//     private bool isTalking = false;
//     private bool isStoppedTalking = false;

//     public InventorySystem inventorySystem;

//     void Start()
//     {
//         inventorySystem = FindObjectOfType<InventorySystem>();
//         EventManager.AddListener<TranslateEvent>(TranslateMessage);
//     }

//     void TranslateMessage(TranslateEvent evt)
//     {
//         for (int i = 0; i < dialogues.Count(); i++)
//         {
//             for (int j = 0; j < dialogues[i].lines.Count(); j++)
//             {
//                 string line = dialogues[i].lines[j];
             
//                 string translatedLine = inventorySystem.TranslateMessage(line);
                
//                 dialogues[i].lines[j] = translatedLine;
//             }
//         }
//     }

//     void Update()
//     {
//         if (!wait && !isTalking)
//             StartCoroutine(CheckForDialogue());
//     }

//     private IEnumerator CheckForDialogue()
//     {
//         wait = true;

//         if (Physics.SphereCast(transform.position, 10, Vector3.zero, out RaycastHit hitInfo))
//         {
//             if (hitInfo.collider.CompareTag("Player"))
//                 StartDialogue();
//         }

//         yield return new WaitForSeconds(0.05f);
//         wait = false;
//     }

//     void StartDialogue()
//     {
//         if (!isStoppedTalking)
//         {
//             isTalking = true;
//             StartCoroutine(TypeLine());
//         }
//     }

//     private IEnumerator TypeLine()
//     {
//        foreach (string rawLine in dialogues[dialogueIndex].lines)
//         {
//             string translatedLine = inventorySystem.TranslateMessage(rawLine);
//             foreach (char c in translatedLine.ToCharArray())
//             {
//                 yield return new WaitForSeconds(waitType);
//             }
//         }

//         if (!dialogues[dialogueIndex].needsAnswer)
//             NextLine();
//     }

//     void NextLine()
//     {
//         if (dialogueIndex < dialogues.Length - 1)
//             dialogueIndex++;
//         else
//             StartCoroutine(StopTalking());
//     }

//     private IEnumerator StopTalking()
//     {
//         isStoppedTalking = true;

//         yield return new WaitForSeconds(5);

//         isStoppedTalking = false;
//     }

//     void Restart()
//     {
//         dialogueIndex = 0;
//         isTalking = false;
//         StopCoroutine(TypeLine());
//     }
// }
