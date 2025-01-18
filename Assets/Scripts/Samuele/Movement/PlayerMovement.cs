using UnityEngine;
using UnityEngine.Splines;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SplineContainer splines;
    [SerializeField] private GameObject moveArrow;

    // Variable for movement
    private int splineIndex = 0;
    private int moveIndex = 0;

    // Variables that check for movement
    public bool canMoveForward { get; private set; }
    public bool canMoveBackward { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // Set up player position
        var splineStartPoint = splines[splineIndex][moveIndex].Position;
        transform.position = new Vector3(splineStartPoint.x, 1, splineStartPoint.z);

        CheckForMovement();
    }

    private void CheckForMovement()
    {
        // Check if player can move forward and/or backward
        if (moveIndex < splines[splineIndex].Count - 1)
            canMoveForward = true;
        else
            canMoveForward = false;
        if (moveIndex > 0)
            canMoveBackward = true;
        else
            canMoveBackward = false;
        
        // Check for intersections
        if (!canMoveForward || !canMoveBackward)
        {
            // Check if there is an intersection
            for (int i = 0; i < splines.Spline.Count; i++)
            {
                if (splineIndex == i) return;

                if (splines[splineIndex][moveIndex].Equals(splines[i][0]))
                {
                    // Instantiate arrow
                    Vector3 posB = splines[i][1].Position;
                    Vector3 posA = splines[i][0].Position;

                    var arrow = Instantiate(moveArrow, posB, Quaternion.identity);
                    arrow.transform.forward = posB - posA;
                    arrow.GetComponent<MyDirection>().index = i;
                    arrow.GetComponent<MyDirection>().knot = 0;
                    arrow.GetComponent<MyDirection>().movement = this;
                }
                else if (splines[splineIndex][moveIndex].Equals(splines[i][splines[i].Count - 1]))
                {
                    var lastIndex = splines[i].Count - 1;

                    // Instantiate arrow
                    Vector3 posB = splines[i][lastIndex - 1].Position;
                    Vector3 posA = splines[i][lastIndex].Position;

                    var arrow = Instantiate(moveArrow, posB, Quaternion.identity);
                    arrow.transform.forward = posB - posA;
                    arrow.GetComponent<MyDirection>().index = i;
                    arrow.GetComponent<MyDirection>().knot = lastIndex;
                    arrow.GetComponent<MyDirection>().movement = this;
                }
            }
        }
    }

    public void ChangeSpline(int index, int knot)
    {
        splineIndex = index;

        if (knot == 0)
            moveIndex = 1;
        else
            moveIndex = knot - 1;

        CheckForMovement();
    }

    public void MoveInSpline(int knot)
    {
        moveIndex += knot;

        transform.position = splines[splineIndex][moveIndex].Position;

        CheckForMovement();
    }

    // Getters
    public Spline GetCurrentSpline() => splines[splineIndex];
    public int GetCurrentIndex() => moveIndex;
}
