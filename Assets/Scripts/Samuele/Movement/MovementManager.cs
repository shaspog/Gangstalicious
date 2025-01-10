using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public List<GameObject> movePoints {
        get => movePoints;
        private set => movePoints = value;
    }

    public int pointIndex {
        get => pointIndex;
        private set => pointIndex = 0;
    }
}