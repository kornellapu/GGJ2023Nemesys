using UnityEngine;
using Managers;

namespace Interactions
{
    public class InteractHandler : MonoBehaviour
    {
        [SerializeField] LayerMask interactableLayerMask;
        Camera characterCamera;

        IInteractable interactable;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            characterCamera = GameManager.Instance.CharecterCamera;
        }

        private void Update()
        {
            if (GameManager.Instance.CurrentState == GameManager.GameState.GameOver)
                return;

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
