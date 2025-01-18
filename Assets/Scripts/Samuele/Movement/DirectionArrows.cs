using UnityEngine;
using UnityEngine.UI;

public class DirectionArrows : MonoBehaviour
{
    [SerializeField] private GameObject arrowUp;
    [SerializeField] private GameObject arrowDown;
    [SerializeField] private PlayerMovement playerMovement;

    private GameObject thisCanvas;

    // Start is called before the first frame update
    void Start()
    {
        arrowUp.GetComponent<Button>().onClick.AddListener(MoveForward);
        arrowDown.GetComponent<Button>().onClick.AddListener(MoveBackward);

        thisCanvas = transform.parent.gameObject;
    }

    void Update()
    {
        thisCanvas.transform.position = playerMovement.gameObject.transform.position;

        var currentSpline = playerMovement.GetCurrentSpline();
        var currentIndex = playerMovement.GetCurrentIndex();

        thisCanvas.transform.forward = currentIndex + 1 > currentSpline.Count ?
            currentSpline[currentIndex].Position - currentSpline[currentIndex - 1].Position :
            currentSpline[currentIndex + 1].Position - currentSpline[currentIndex].Position;
        
        if (playerMovement.canMoveForward)
            arrowUp.SetActive(true);
        else
            arrowUp.SetActive(false);
        
        if (playerMovement.canMoveBackward)
            arrowDown.SetActive(true);
        else
            arrowDown.SetActive(false);
    }

    private void MoveForward()
    {
        playerMovement.MoveInSpline(1);
    }

    private void MoveBackward()
    {
        playerMovement.MoveInSpline(-1);
    }
}
