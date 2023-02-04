using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public Player Player { get; private set; }
        public Camera charecterCamera;

        private void Start()
        {
            if (Player == null)
                Player = GameObject.Find("Player").GetComponent<Player>();

            OxygenManager.Instance.Init();
        }
    }
}
