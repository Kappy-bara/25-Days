using TMPro;
using UnityEngine;

public class TaklToNPC : MonoBehaviour, IInteractable
{
    private bool isInteracting = false;
    public void Interacter(TextMeshProUGUI interactionText)
    {
        if (isInteracting)
        {
            Interact();
        }
        else
        {
            interactionText.text = "Press E";
            if (Input.GetKeyDown(KeyCode.E)) isInteracting = true;
        }

    }
    public void Interact()
    {

    }
}
