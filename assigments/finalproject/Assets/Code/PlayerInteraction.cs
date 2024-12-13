using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 5f;   
    public TMP_Text interactionText;    
    private SelectableItem currentSelectable; 
    void Update()
    {
  
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactDistance);
        bool itemFound = false;

        foreach (var hitCollider in hitColliders)
        {
            SelectableItem selectable = hitCollider.GetComponent<SelectableItem>();
            if (selectable != null)
            {
             
                itemFound = true;
                currentSelectable = selectable;

        
                interactionText.text = "Press 'T' to collect item";

    
                if (Input.GetKeyDown(KeyCode.T))
                {
                    currentSelectable.ShowItemPanel();
                }

                break; 
            }
        }

        if (!itemFound && currentSelectable != null)
        {

            interactionText.text = "";
            currentSelectable = null;
        }
    }
}
