using UnityEngine;

namespace Managers
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected void Awake()
        {
            Debug.Log(this.gameObject.name);
            if (Instance != null && Instance != this)

            {
                Destroy(this);
                Debug.Log($" An Instance of Sinleton<T> is already exists!");
                return;
            }

            Instance = this as T;
        }
    }

}