using UnityEngine;

public class MyDirection : MonoBehaviour
{
    public int index;
    public int knot;
    public PlayerMovement movement;

    public void OnClick()
    {
        movement.ChangeSpline(index, knot);

        Destroy(gameObject);
    }
}