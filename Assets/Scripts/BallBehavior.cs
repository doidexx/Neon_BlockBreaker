using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField]
    Transform paddle;

    [SerializeField]
    float offset;

    [SerializeField]
    Vector2 launchDirection;

    Rigidbody2D rb;

    bool launched;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        launched = false;
        transform.position = new Vector2(paddle.position.x, paddle.position.y + offset);
    }
    
    void Update()
    {
        if (!launched)
        {
            LaunchOnClick();
            LockBallToPaddle();
        }
    }

    void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = launchDirection;
            launched = true;
        }
    }

    void LockBallToPaddle()
    {
        var ballNewX = Mathf.Lerp(transform.position.x, paddle.position.x, 0.5f);
        transform.position = new Vector2(paddle.position.x, paddle.position.y + offset);
    }
}
