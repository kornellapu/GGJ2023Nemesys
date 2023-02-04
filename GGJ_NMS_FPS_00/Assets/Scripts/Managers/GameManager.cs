using EvolveGames;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public Player Player;
        public PlayerController PlayerController;
        public Camera CharecterCamera;

		public UnityAction OnGameOver;

		private CameraFade cameraFade;

        private void Start()
        {
            if (Player == null)
                Player = GameObject.Find("Player").GetComponent<Player>();

            OxygenManager.Instance.Init();
            cameraFade = CharecterCamera.GetComponent<CameraFade>();
            OnGameOver += () => GameOver();
        }

        private void GameOver()
        {
            cameraFade.StartDeathAnimation();
            PlayerController.canMove = false;
        }
    }
}
