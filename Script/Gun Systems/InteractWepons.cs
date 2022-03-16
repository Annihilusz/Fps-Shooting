using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractWepons : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 5f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    private void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit , interactionDistance))
        {
            print(11111111);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
                
            }
            
        }
        else
        {
            hitSomething = false;
        }

        interactionUI.SetActive(hitSomething);
    }
}
