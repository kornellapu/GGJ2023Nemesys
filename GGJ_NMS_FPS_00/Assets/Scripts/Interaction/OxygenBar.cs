using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
using Managers;

public class OxygenBar : MonoBehaviour, IInteractable
{
    public bool isCharging;
    public bool isToggle;
    public float OxygenLevel;

    void Start()
    {
        Init();   
    }

    public void Init()
    {
        isToggle = false;
        isCharging = false;
        OxygenLevel = 100;
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        OxygenManager.Instance.OnChargeCanceld += (float leftOver) => { if(isCharging) OxygenLevel -= OxygenLevel-leftOver; isCharging = false; };
    }

    public void Interact()
    {
        /*if (isToggle)
            return;*/
        if (isCharging)
            return;
        Toggle(true);
        isCharging = true;
        OxygenManager.Instance.StartChargingOxygenBar(OxygenLevel);
    }

    public void Cancel()
    {
        /* if (!isToggle)
             return;*/
        if (!isCharging)
            return;
        OxygenManager.Instance.StopChargingOxygenBar();
        Toggle(false);
    }

    public void Toggle(bool state)
    {
        isToggle = state;
    }

    public void Hover()
    {
        OxygenManager.Instance.ShowOxygenBarUI(true, OxygenLevel);
    }

    public void CancelHover()
    {
		OxygenManager.Instance.ShowOxygenBarUI(false);
	}
}
