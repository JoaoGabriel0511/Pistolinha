using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallCollisionBehaviour : ScriptableObject
{
    public abstract void ResolveCollision(Wall wall, BallMovement ball);
}
