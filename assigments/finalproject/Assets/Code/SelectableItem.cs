using UnityEngine;

public class SelectableItem : MonoBehaviour
{
    public GameObject itemPanel; 
    public GameObject closeButton;

    public void ShowItemPanel()
    {
        itemPanel.SetActive(true);
        closeButton.SetActive(true);
    }

    public void HideItemPanel()
    {
        itemPanel.SetActive(false);
        closeButton.SetActive(false); 
    }
}
