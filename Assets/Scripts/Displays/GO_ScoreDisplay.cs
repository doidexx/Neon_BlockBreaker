using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GO_ScoreDisplay : MonoBehaviour
{
    [SerializeField] LevelProgression progresison;

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + progresison.lastScore;
    }
}
