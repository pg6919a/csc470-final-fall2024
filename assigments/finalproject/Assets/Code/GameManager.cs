using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timer = 300f; 
    public GameObject gameOverPanel; 
    public TextMeshProUGUI timerText;

    private bool isGameOver = false;

    private void Update()
    {
        if (isGameOver) return;

        timer -= Time.deltaTime;


        UpdateTimerUI();


        if (timer <= 0f)
        {
            GameOver();
        }
    }

    private void UpdateTimerUI()
    {
       
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        isGameOver = true;
        timer = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}
