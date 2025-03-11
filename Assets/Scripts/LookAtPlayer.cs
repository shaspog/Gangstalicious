using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform playerHead; // Drag the player's camera here in Inspector

    void Update()
    {
        transform.LookAt(playerHead);
        transform.Rotate(0, 180, 0); // Flip if it's facing backwards
    }
}
