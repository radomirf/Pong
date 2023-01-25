using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreControl scoreControl;
    void BounceFromPlayer(Collision2D c)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 playerPosition = c.gameObject.transform.position;

        float racketHight = c.collider.bounds.size.y;
        float x;
        if (c.gameObject.name == "Player1")
        {
            x = 1;
        }
        else
            x = -1;

        float y = (ballPosition.y - playerPosition.y) / racketHight;
        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Player1" || collision.gameObject.name == "Player2")
        {
            this.BounceFromPlayer(collision);
        }
        else if(collision.gameObject.name== "WallLeft")
        {
            this.scoreControl.GoalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(true));
          
        }
        else if (collision.gameObject.name == "WallRight")
        {
            this.scoreControl.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}
