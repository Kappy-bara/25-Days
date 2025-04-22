using TMPro;
using UnityEngine;
interface IInteractable
{
    public void Interacter(TextMeshProUGUI interaction_Text);
}

public class Interaction : MonoBehaviour
{
    public float interactionDistance = 5f;
    public Transform cameraTransform;
    public TextMeshProUGUI interactionText;

    void Start()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
    }

    void Update()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);
        RaycastHit hit;
        Physics.Raycast(ray, out hit,interactionDistance);
        if (hit.collider != null && hit.collider.CompareTag("Interactable"))
        {
            GameObject obj = hit.collider.gameObject;
            obj.GetComponent<IInteractable>().Interacter(interactionText);
        }
        else interactionText.text = "";

    }
}
