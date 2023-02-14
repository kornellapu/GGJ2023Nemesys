using UnityEngine;
using Managers;

namespace Interactions
{
	public class InteractHandler : MonoBehaviour
	{
		[SerializeField] LayerMask interactableLayerMask;
		[SerializeField] RectTransform Rect_Interact_UI;
		Camera characterCamera;

		IInteractable interactable;

		private void Start()
		{
			Init();
		}

		public void Init()
		{
			characterCamera = GameManager.Instance.CharecterCamera;
			Rect_Interact_UI.gameObject.SetActive(false);

		}

		private void Update()
		{
			if (GameManager.Instance.CurrentState == GameManager.GameState.GameOver)
				return;

			RaycastHit hit;

			if (Physics.Raycast(characterCamera.transform.position, characterCamera.transform.forward, out hit, 2, interactableLayerMask))
			{
				interactable = hit.collider.GetComponent<IInteractable>();
				if (interactable == null)
					return;

				if (Input.GetKeyDown(KeyCode.E))
					interactable.Interact();

				if (Input.GetKeyUp(KeyCode.E))
					interactable.Cancel();

				interactable.Hover();
				Rect_Interact_UI.gameObject.SetActive(true);
			}
			else if (interactable != null)
			{
				interactable.Cancel();
				interactable.CancelHover();
				interactable = null;
				Rect_Interact_UI.gameObject.SetActive(false);
			}
		}
	}

}
