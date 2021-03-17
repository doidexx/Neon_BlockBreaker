using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadMain()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public static void LoadGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    public static void LoadGameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }
}
