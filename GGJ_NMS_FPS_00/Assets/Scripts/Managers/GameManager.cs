using EvolveGames;
using Interactions;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public enum GameState
        {
            Init,
            Gameplay,
            GameOver
        }

        public GameState CurrentState;
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
            CurrentState = GameState.Init;
        }

        private void GameOver()
        {
			CurrentState = GameState.GameOver;
			cameraFade.StartDeathAnimation();
            PlayerController.canMove = false;
            StartCoroutine(IEGameOver());
        }

        private IEnumerator IEGameOver()
        {
            yield return new WaitForSeconds(3);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
			SceneManager.LoadScene("FinalMenu");
		}
    }
}
