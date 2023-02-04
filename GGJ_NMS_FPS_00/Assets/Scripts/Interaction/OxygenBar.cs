using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
using Managers;

public class OxygenBar : MonoBehaviour, IInteractable
{
    public bool isCharging;
    private bool isToggle;
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
        OxygenManager.Instance.OnChargeCanceld += (float leftOver) => { OxygenLevel -= OxygenLevel-leftOver; };
    }

    public void Interact()
    {
        if (isToggle)
            return;
        Toggle(true);
        OxygenManager.Instance.StartChargingOxygenBar(OxygenLevel);
    }

    public void Cancel()
    {
        if (!isToggle)
            return;
        OxygenManager.Instance.StopChargingOxygenBar();
        Toggle(false);
    }

    public void Toggle(bool state)
    {
        isToggle = state;
    }
}
