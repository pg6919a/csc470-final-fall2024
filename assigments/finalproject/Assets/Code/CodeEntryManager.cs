using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CodeEntryManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI wrongCodeMessage;
    public GameObject winPanel;
    public Button restartButton;
    public Transform player;
    public float interactionDistance = 5f;

    private const string correctCode = "777";
    private bool isInRange = false;

    private void Start()
    {
        inputField.gameObject.SetActive(false);
        winPanel.SetActive(false);
        wrongCodeMessage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= interactionDistance)
        {
            if (!isInRange)
            {
                inputField.gameObject.SetActive(true);
                isInRange = true;
            }
        }
        else
        {
            if (isInRange)
            {
                inputField.gameObject.SetActive(false);
                isInRange = false;
            }
        }
    }

    public void CheckCode()
    {
        string enteredCode = inputField.text;

        if (enteredCode == correctCode)
        {
            winPanel.SetActive(true);
            inputField.gameObject.SetActive(false); // Hide the input field
        }
        else
        {
            wrongCodeMessage.gameObject.SetActive(true);
            Invoke("HideWrongCodeMessage", 3f);
        }
    }

    private void HideWrongCodeMessage()
    {
        wrongCodeMessage.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
