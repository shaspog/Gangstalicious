using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoints : MonoBehaviour
{
    public Transform destination;
    private MovementScript movementScript;

    private void Start()
    {
        movementScript = FindObjectOfType<MovementScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            movementScript.TeleportTo(destination);
        }

    }
}
