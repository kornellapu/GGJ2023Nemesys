using UnityEngine;

namespace Interactions
{
    public interface IInteractable
    {
        public void Interact();

        public void Cancel();

		public void Hover();

		public void CancelHover();

		public void Toggle(bool state);
    } 
}
