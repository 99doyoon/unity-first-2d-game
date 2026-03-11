using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject clearText;
    public TextMeshProUGUI scoreText;

    public int score = 0;
    public int targetScore = 3;

    public bool isGameOver = false;
    public bool isClear = false;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        if ((isGameOver || isClear) && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void AddScore(int amount)
    {
        if (isGameOver || isClear)
            return;

        score += amount;
        UpdateScoreUI();

        if (score >= targetScore)
        {
            ClearGame();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        if (isGameOver || isClear)
            return;

        isGameOver = true;

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void ClearGame()
    {
        if (isGameOver || isClear)
            return;

        isClear = true;

        if (clearText != null)
        {
            clearText.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}