using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] LevelManager manager;

    private void LateUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = "lvl: " + manager.lvl.ToString();
    }
}
