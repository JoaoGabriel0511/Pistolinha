using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ball Behaviour/Green Ball")]
public class GreenBall : BallCollisionBehaviour
{
    public override void ResolveCollision(GameObject go, BallMovement ball)
    {
        if (go.GetComponent<IColorful>() != null)
        {
            Wall wall = go.GetComponent<Wall>();
            if (wall != null)
            {
                switch (wall.GetColor())
                {
                    case Constants.Type.GREEN:
                        ball.StartCoroutine("MakeDeath", wall);
                        break;
                    case Constants.Type.RED:
                        ball.StartCoroutine("MakeColision", wall);
                        break;
                    case Constants.Type.BLUE:
                        ball.StartCoroutine("MakePhase");
                        break;
                }
            }
        }
    }
}
