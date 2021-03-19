using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] LevelManager manager;

    private void LateUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = "score: " + manager.score.ToString();
    }
}
