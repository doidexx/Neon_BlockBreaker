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

    [SerializeField]
    int winScene;

    private void Start()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        if (activeScene == startScreenIndex)
        {
            FindObjectOfType<GameStatus>().DestroyScore();
        }
        if (activeScene == winScene)
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
        else if (activeScene == winScene)
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
        SceneManager.LoadScene("GameOver");
        FindObjectOfType<GameStatus>().ShowFinalScore();
    }
}
