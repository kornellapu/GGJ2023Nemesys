using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {

        [SerializeField] Player player;
        public UnityAction<float> OnChargeCanceld;
        private bool stopCharge;

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            stopCharge = false;
        }

        public void ChargeOxygenBar(float maxAmount)
        {
            if (maxAmount == 0)
                return;
            StartCoroutine(IEChargeOxygenBar(maxAmount));
        }

        public void StopChargingOxygenBar()
        {
            Debug.Log("cancel");
            stopCharge = true;
        }

        private IEnumerator IEChargeOxygenBar(float maxAmount)
        {
            Debug.Log("Start Corrutine");

            while (player.IncreaseOxygenLevelByValue(0.5f) && maxAmount > 0.0f && !stopCharge)
            {
                maxAmount -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }

            Debug.Log("corrutine stopped " + player.IncreaseOxygenLevelByValue(0.5f) + " " + maxAmount + " " + stopCharge);

            stopCharge = false;
            OnChargeCanceld.Invoke(maxAmount);
        }
    }
}
