using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartClick : MonoBehaviour
{
    LevelManager levelManager;

    TextMeshProUGUI text;

    Color baseColor;

    bool lightsOn;

    [SerializeField]
    float changeSpeed;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        levelManager = FindObjectOfType<LevelManager>();
        baseColor = text.color;
        lightsOn = true;
    }

    private void Update()
    {
        if (text.color == baseColor)
        {
            lightsOn = true;
        }
        if (text.color == Color.black)
        {
            lightsOn = false;
        }
        if (lightsOn)
        {
            text.color = Color.Lerp(baseColor, Color.black, Time.fixedTime * changeSpeed);
        }
        else
        {
            text.color = Color.Lerp(Color.black, baseColor, Time.fixedTime * changeSpeed);
        }
        if (Input.GetMouseButtonDown(0))
        {
            levelManager.LoadNextLevel();
        }

    }
}
