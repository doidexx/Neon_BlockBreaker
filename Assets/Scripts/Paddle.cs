using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float screenWidthInUnits;

    [SerializeField]
    float paddleOffSet;

    [SerializeField]
    float maxX;

    [SerializeField]
    float minX;

    void Update()
    {
        var mouseXPos = (Input.mousePosition.x / Screen.width * screenWidthInUnits);
        transform.position = new Vector2(Mathf.Clamp(mouseXPos + paddleOffSet, minX, maxX), transform.position.y);
    }
}
