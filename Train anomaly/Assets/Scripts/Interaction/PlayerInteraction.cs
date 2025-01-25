using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 10f;
    public GameObject interactionUI;
    public Text interactionText;

    private void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;
        bool hitSomthing = false;
        if(Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if(interactable != null)
            {
                hitSomthing = true;
                interactionText.text = interactable.GetDescription();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        interactionUI.SetActive(hitSomthing);
    }
}
