using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public scoreController scoreController;

    void BounceFromRocket(Collision2D c)
    {
        Vector3 ballPosition = this.transform.position; 
        Vector3 rocketPosition = c.gameObject.transform.position;

        float rocketHight = c.collider.bounds.size.y;
        float x;

        if(c.gameObject.name == "RocketPl1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        float y = (ballPosition.y - rocketPosition.y) / rocketHight;
        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x,y));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "RocketPl1" || collision.gameObject.name == "RocketPl2")
        {
            this.BounceFromRocket(collision);
        }
        else if (collision.gameObject.name == "WallLeft")
        {
            Debug.Log("Coll WALL");
            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "WallRight")
        {
            Debug.Log("Coll WALL RIGHT");
            this.scoreController.GoalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }

}
