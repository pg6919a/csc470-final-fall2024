using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TextMeshProUGUI healthText; 
    public GameObject gameOverPanel;

    void Start()
    {
    
        UpdateHealthUI();
        gameOverPanel.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        
        if (collision.gameObject.CompareTag("Guard"))
        {
            health--;
            Debug.Log("Health decreased to: " + health);
            
            UpdateHealthUI();

            if (health <= 0)
            {
                GameOver();
            }
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health; 
            Debug.Log("Health UI updated: " + health); 
        }
        else
        {
            Debug.LogError("Health TextMeshProUGUI is not assigned!");
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over triggered."); 
        gameOverPanel.SetActive(true); 
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
