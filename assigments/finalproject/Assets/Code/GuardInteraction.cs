using UnityEngine;
using TMPro;

public class GuardInteraction : MonoBehaviour
{
    public TMP_Text messageText;
    public TMP_Text guardsKilledText;
    public string guardTag = "Guard";
    private float messageDuration = 2f; 
    private float messageTimer = 0f;
    private static int guardsKilled = 0;  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(guardTag))
                {
                    Destroy(hit.collider.gameObject);
                    ShowMessage("You killed the guard");
                    UpdateGuardsKilled();
                }
            }
        }

        if (messageTimer > 0f)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0f)
            {
                messageText.gameObject.SetActive(false); 
            }
        }
    }

    void ShowMessage(string message)
    {
        messageText.gameObject.SetActive(true);
        messageText.text = message;
        messageTimer = messageDuration;
    }

    void UpdateGuardsKilled()
    {
        guardsKilled++; 
        guardsKilledText.text = "Guards Killed: " + guardsKilled; 
    }
}
