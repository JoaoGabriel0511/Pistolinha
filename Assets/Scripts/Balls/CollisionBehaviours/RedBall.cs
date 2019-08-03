using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ball Behaviour/Red Ball")]
public class RedBall : BallCollisionBehaviour
{
    public override void ResolveCollision(Wall wall, BallMovement ballMovement)
    {
        switch (wall.GetColor())
        {
            case Constants.Type.RED:
                //ballMovement.ColisionWithWall(wall.Angle);
                break;
            case Constants.Type.BLUE:
                break;
            case Constants.Type.GREEN:
                Destroy(ballMovement.gameObject);
                break;
        }
    }
}
