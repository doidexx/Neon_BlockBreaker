using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] Image[] ballSprite;
    
    public void DisableLive(int lives)
    {
        lives = Mathf.Max(0, lives);
        ballSprite[lives].enabled = false;
    }
}
