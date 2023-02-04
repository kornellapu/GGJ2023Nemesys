using UnityEngine;

namespace Interactions
{
    public class InteractHandler : MonoBehaviour
    {
        [SerializeField] LayerMask interactableLayerMask;
        [SerializeField] Camera characterCamera;

        private void Update()
        {
            RaycastHit hit;

            if (Physics.Raycast(characterCamera.transform.position, characterCamera.transform.forward, out hit, 10, interactableLayerMask))
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable == null)
                    return;

                if (Input.GetMouseButtonDown(0))
                    interactable.Interact();

            }
        }
    }

}
