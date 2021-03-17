using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float XMax;

    private void Update()
    {
        float XInput = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float newX = transform.position.x + XInput;
        newX = Mathf.Clamp(newX, -XMax, XMax);
        transform.position = new Vector2(newX, transform.position.y);
    }
}
