using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] //Serialized for Debugging
    int activeScene;

    [SerializeField]
    int startScreenIndex;

    private void Start()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        if (activeScene == startScreenIndex)
        {
            FindObjectOfType<GameStatus>().DestroyScore();
        }
        if (activeScene == SceneManager.sceneCountInBuildSettings - 2)
        {
            FindObjectOfType<GameStatus>().ShowFinalScore();
        }
    }

    public void LoadNextLevel()
    {
        if (activeScene + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else if (activeScene == SceneManager.sceneCountInBuildSettings - 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(activeScene + 1);
        }
    }

    public void LoseScreen()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        FindObjectOfType<GameStatus>().ShowFinalScore();
    }
}
