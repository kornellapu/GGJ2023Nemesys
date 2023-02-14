using EvolveGames;
using Interactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

		[SerializeField] RectTransform Rect_InGame_UI;
		[SerializeField] RectTransform Rect_End_UI;
		[SerializeField] Button Button_Menu;
		[SerializeField] List<Lever> GeneratorLevers;

		public GameState CurrentState;
		public Player Player;
		public PlayerController PlayerController;
		public Camera CharecterCamera;

		public UnityAction<bool> OnGameOver;

		private CameraFade cameraFade;

		private void Start()
		{
			if (Player == null)
				Player = GameObject.Find("Player").GetComponent<Player>();

			OxygenManager.Instance.Init();
			cameraFade = CharecterCamera.GetComponent<CameraFade>();
			OnGameOver += (bool escaped) => { if (escaped) Escaped(); else GameOver(); };
			CurrentState = GameState.Init;
			Rect_InGame_UI.gameObject.SetActive(true);
			Button_Menu.onClick.AddListener(() => SceneManager.LoadScene("FinalMenu"));
		}

		private void GameOver()
		{
			if (!PlayerController.canMove)
				return;

			CurrentState = GameState.GameOver;
			cameraFade.StartDeathAnimation();
			PlayerController.canMove = false;
			StartCoroutine(IEGameOver());
		}

		public void ActivateGeneratorLever(Lever lever)
		{
			if (GeneratorLevers.FindAll(x => x.ClickedOnce == true).Count >= 2)
				OnGameOver.Invoke(true);
		}

		private void Escaped()
		{
			Rect_InGame_UI.gameObject.SetActive(false);
			Rect_End_UI.gameObject.SetActive(true);
			PlayerController.canMove = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
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
