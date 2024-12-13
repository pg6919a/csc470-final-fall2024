using UnityEngine;

public class CloseButton : MonoBehaviour
{

    public void ClosePanel(GameObject panel)
{
    panel.SetActive(false);
}

    public SelectableItem selectableItem; 

    public void OnCloseButtonClicked()
    {
        if (selectableItem != null)
        {
            selectableItem.HideItemPanel(); 
        }
    }
}
