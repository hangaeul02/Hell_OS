using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver = false;
    public int totalScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        totalScore += amount;
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        totalScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}