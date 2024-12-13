using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timer = 300f; // 5 minutes in seconds
    public GameObject gameOverPanel; // Assign this in the Inspector
    public TextMeshProUGUI timerText; // Assign this in the Inspector (for displaying the timer)

    private bool isGameOver = false;

    private void Update()
    {
        if (isGameOver) return;

        // Reduce the timer
        timer -= Time.deltaTime;

        // Update the timer text on the UI
        UpdateTimerUI();

        // Check if the timer has reached 0
        if (timer <= 0f)
        {
            GameOver();
        }
    }

    private void UpdateTimerUI()
    {
        // Format the timer as MM:SS
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        isGameOver = true;
        timer = 0; // Clamp the timer to 0
        gameOverPanel.SetActive(true); // Show the Game Over panel
    }

    public void RestartGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}
