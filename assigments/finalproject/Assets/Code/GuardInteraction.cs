using UnityEngine;
using TMPro;

public class GuardInteraction : MonoBehaviour
{
    public TMP_Text messageText;
    public string guardTag = "Guard";
    private float messageDuration = 2f; 
    private float messageTimer = 0f;

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
                    ShowMessage("you killed the guard");
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
}
