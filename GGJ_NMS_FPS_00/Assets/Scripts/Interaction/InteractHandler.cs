using UnityEngine;

namespace Interactions
{
    public class InteractHandler : MonoBehaviour
    {
        [SerializeField] LayerMask interactableLayerMask;
        [SerializeField] Camera characterCamera;

        IInteractable interactable;

        private void Update()
        {
            RaycastHit hit;

            if (Physics.Raycast(characterCamera.transform.position, characterCamera.transform.forward, out hit, 10, interactableLayerMask))
            {
                interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable == null)
                    return;

                if (Input.GetMouseButtonDown(0))
                    interactable.Interact();

                if (Input.GetMouseButtonUp(0))
                    interactable.Cancel();

            }
            else if (interactable != null)
            {
                interactable.Cancel();
                interactable = null;
            }
        }
    }

}
