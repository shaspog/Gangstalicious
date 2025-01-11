using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementScript : MonoBehaviour
{
    public GameObject player;
    public float teleportDelay = 0.5f;

    public void TeleportTo(Transform destination)
    {
        StartCoroutine(TeleportAfterDelay(destination.position));
    }

    private IEnumerator TeleportAfterDelay(Vector3 destination)
    {
        yield return new WaitForSeconds(teleportDelay);
        player.transform.position = destination;
    }

}
