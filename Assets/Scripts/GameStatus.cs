using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int currentScore = 0;

    [SerializeField] int scorePerBlockDestroyed = 83;

    [SerializeField] TextMeshProUGUI score;

    [SerializeField] TextMeshProUGUI finalScore;

    [SerializeField] string finalScoreText;

    private void Awake()
    {
        int gameStatusObject = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusObject > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        score.text = currentScore.ToString();
    }

    public void AddToScore()
    {
        currentScore += scorePerBlockDestroyed;
        score.text = currentScore.ToString();
    }

    public void DestroyScore()
    {
        Destroy(gameObject);
    }

    public void ShowFinalScore()
    {
        finalScore.text = finalScoreText + score.text;
        score.gameObject.SetActive(false);
        finalScore.gameObject.SetActive(true);
    }
}
