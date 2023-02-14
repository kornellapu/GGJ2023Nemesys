using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Managers
{
	public class OxygenManager : Singleton<OxygenManager>
	{
		public enum OxygenUsageState
		{
			IDLE,
			WALK,
			RUN,
		}

		[SerializeField] AudioSource footSteps;
		[SerializeField] RectTransform Rect_OxygenBar;
		[SerializeField] Slider Slider_OxygenBar;
		[SerializeField] TextMeshProUGUI Text_OxygenPercent;

		public UnityAction<float> OnChargeCanceld;
		public UnityAction OnExitSafeZone;
		public UnityAction OnEnterSafeZone;
		public UnityAction OnAttack;

		private bool underAttack;

		[HideInInspector] public bool inSaveZone = true;

		private bool stopCharge;
		private bool running = false;
		private float oxygenUsage;

		private Player player;

		public void Init()
		{
			player = GameManager.Instance.Player;
			footSteps = GameObject.Find("StepAudioSource").GetComponent<AudioSource>();
			Rect_OxygenBar.gameObject.SetActive(false);
			stopCharge = false;
			underAttack = false;

			OnExitSafeZone += () => { if (inSaveZone) StopAllCoroutines(); StartCoroutine(IEUseOxygen()); };
			OnEnterSafeZone += () => { inSaveZone = true; };

			SetOxygenUsage(OxygenUsageState.IDLE);
			StartCoroutine(IEUseOxygen());
		}

		public void SetOxygenUsage(OxygenUsageState state)
		{
			float bonusUsage = underAttack ? 0.1f : 0.0f;
			switch (state)
			{
				case OxygenUsageState.IDLE:
					oxygenUsage = 0.005f + bonusUsage;  ///0.01
					footSteps.pitch = 0;
					break;
				case OxygenUsageState.WALK:
					oxygenUsage = 0.01f + bonusUsage; ///0.03
					footSteps.pitch = 1.3f;
					break;
				case OxygenUsageState.RUN:
					oxygenUsage = 0.05f + bonusUsage; ///0.1
					footSteps.pitch = 2f;
					break;
				default:
					oxygenUsage = 0.001f;
					break;
			}
		}

		public void SetUnderAttack(bool state)
		{
			underAttack = state;
		}

		public void StartChargingOxygenBar(float maxAmount)
		{
			if (maxAmount == 0)
				return;
			StartCoroutine(IEChargeOxygenBar(maxAmount));
			OnEnterSafeZone.Invoke();
		}

		public void StopChargingOxygenBar()
		{
			stopCharge = true;
		}

		public void EnterSafeZone()
		{
			OnEnterSafeZone.Invoke();
		}

		public void ExitSafeZone()
		{
			OnExitSafeZone.Invoke();
		}

		public void ShowOxygenBarUI(bool state, float amount = 100)
		{
			if (Rect_OxygenBar.gameObject.activeInHierarchy == state)
				return;
			Rect_OxygenBar.gameObject.SetActive(state);
			Slider_OxygenBar.value = amount;
			Text_OxygenPercent.text = $"{Math.Floor(Slider_OxygenBar.value)} %";
		}

		private IEnumerator IEChargeOxygenBar(float maxAmount)
		{
			Rect_OxygenBar.gameObject.SetActive(true);

			while (player.IncreaseOxygenLevelByValue(0.3f) && maxAmount > 0.0f && !stopCharge)
			{
				maxAmount -= 0.3f;
				Slider_OxygenBar.value -= 0.3f;
				Text_OxygenPercent.text = $"{Math.Floor(Slider_OxygenBar.value)} %";
				yield return new WaitForSeconds(0.01f);
			}

			stopCharge = false;
			OnChargeCanceld.Invoke(maxAmount);
			OnExitSafeZone.Invoke();
		}
		private IEnumerator IEUseOxygen()
		{
			if (inSaveZone)
				yield return null;

			if (running)
				yield return null;

			running = true;
			inSaveZone = false;
			Rect_OxygenBar.gameObject.SetActive(false);
			yield return new WaitForSeconds(1);

			while (player.IncreaseOxygenLevelByValue(-oxygenUsage))
			{
				yield return new WaitForSeconds(0.01f);
			}

			GameManager.Instance.OnGameOver.Invoke(false);
		}
	}

}