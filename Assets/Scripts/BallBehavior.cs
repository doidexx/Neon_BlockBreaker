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

    bool launched;

    void Start()
    {
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
            launched = true;
            GetComponent<Rigidbody2D>().velocity = launchDirection;
        }
    }

    void LockBallToPaddle()
    {
        var ballNewX = Mathf.Lerp(transform.position.x, paddle.position.x, 0.5f);
        transform.position = new Vector2(paddle.position.x, paddle.position.y + offset);
    }
}
