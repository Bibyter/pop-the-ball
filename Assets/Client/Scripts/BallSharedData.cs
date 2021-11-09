using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public sealed class BallSharedData : MonoBehaviour
    {
        [System.NonSerialized] public float deadBorder;
        [System.NonSerialized] public int fallsCount;
        [System.NonSerialized] public Vector2 startVelocity;
    }
}