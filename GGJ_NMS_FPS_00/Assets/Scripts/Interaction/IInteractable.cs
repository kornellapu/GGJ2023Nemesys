using UnityEngine;

namespace Interactions
{
    public interface IInteractable
    {
        public void Interact();

        public void Cancel();

        public void Toggle(bool state);
    } 
}
