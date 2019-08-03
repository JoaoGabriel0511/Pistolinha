using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ball Behaviour/Green Ball")]
public class GreenBall : BallCollisionBehaviour
{
    public override void ResolveCollision(Wall wall, BallMovement ball)
    {
        switch (wall.GetColor())
        {
            case Constants.Type.GREEN:
                Destroy(ball.gameObject);
                break;
            case Constants.Type.RED:
                //ball.ColisionWithWall(wall.Angle);
                break;
            case Constants.Type.BLUE:
                break;
        }
    }
}
