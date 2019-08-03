using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ball Behaviour/Blue Ball")]
public class BlueBall : BallCollisionBehaviour
{
    public override void ResolveCollision(Wall wall, BallMovement ball)
    {
        switch (wall.GetColor())
        {
            case Constants.Type.BLUE:
                break;
            case Constants.Type.GREEN:
                //ball.ColisionWithWall(wall.Angle);
                break;
            case Constants.Type.RED:
                Destroy(ball.gameObject);
                break;
        }
    }
}
