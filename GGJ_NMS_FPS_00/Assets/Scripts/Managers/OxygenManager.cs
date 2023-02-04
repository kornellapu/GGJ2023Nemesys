using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class OxygenManager : Singleton<OxygenManager>
    {
        public enum OxygenUsageState
        {
            IDLE,
            WALK,
            RUN
        }

        public UnityAction<float> OnChargeCanceld;
        public UnityAction OnExitSafeZone;
        public UnityAction OnEnterSafeZone;

        private bool stopCharge;
        private float oxygenUsage;

        private Player player;

        public void Init()
        {
            player = GameManager.Instance.Player;
            stopCharge = false;

            OnExitSafeZone += () => StartCoroutine(IEUseOxygen());
            OnEnterSafeZone += () => StopCoroutine(IEUseOxygen());

            SetOxygenUsage(OxygenUsageState.IDLE);
            OnExitSafeZone.Invoke();
        }

        public void SetOxygenUsage(OxygenUsageState state)
        {
            switch (state)
            {
                case OxygenUsageState.IDLE:
                    oxygenUsage = 0.001f;
                    break;
                case OxygenUsageState.WALK:
                    oxygenUsage = 0.005f;
                    break;
                case OxygenUsageState.RUN:
                    oxygenUsage = 0.01f;
                    break;
                default:
                    oxygenUsage = 0.001f;
                    break;
            }
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

        private IEnumerator IEChargeOxygenBar(float maxAmount)
        {
            while (player.IncreaseOxygenLevelByValue(0.1f) && maxAmount > 0.0f && !stopCharge)
            {
                maxAmount -= 0.1f;
                yield return new WaitForSeconds(0.01f);
            }

            stopCharge = false;
            OnChargeCanceld.Invoke(maxAmount);
            OnExitSafeZone.Invoke();
        }
        private IEnumerator IEUseOxygen()
        {
            
            yield return new WaitForSeconds(2);
            while (player.IncreaseOxygenLevelByValue(-oxygenUsage))
            {
                yield return new WaitForSeconds(0.01f);
            }

            Debug.Log("oxygen level");
            //start death event on out of oxygen
            GameManager.Instance.OnGameOver.Invoke();
        }
    }

}