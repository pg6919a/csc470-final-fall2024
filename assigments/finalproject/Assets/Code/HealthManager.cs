using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject youDiedPanel;

    private int health = 3;

    void Start()
    {
        youDiedPanel.SetActive(false);
    }

    public void TakeDamage() 
    {
        health--; 

        UpdateHearts();

        if (health <= 0)
        {
            GameOver();
        }
    }

    void UpdateHearts()
    {
    
        if (health == 2)
            heart3.SetActive(false);
        else if (health == 1)
            heart2.SetActive(false);
        else if (health == 0)
            heart1.SetActive(false);
    }

    void GameOver()
    {
        youDiedPanel.SetActive(true); 
        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
