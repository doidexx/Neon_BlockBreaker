using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollider : MonoBehaviour
{
    [SerializeField] BallBehavior ball;
    [SerializeField] LivesDisplay display;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball.lives--;
        display.DisableLive(ball.lives);
        if (ball.lives <= 0)
        {
            FindObjectOfType<LevelManager>().LoadGameOver();
            return;
        }
        ball.ResetBall();
    }
}
