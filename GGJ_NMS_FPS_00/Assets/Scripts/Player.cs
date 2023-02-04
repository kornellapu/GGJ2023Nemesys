using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("References/UI")]
    [SerializeField] RectTransform Rect_Oxygen;
    [SerializeField] Slider Slider_Oxygen;

    [Header("References/Variables")]
    [SerializeField] int maxOxygenLevel = 100;

    [Range(0,100)]
    [SerializeField] float oxygenLevel;


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if (oxygenLevel == 0)
            SetOxygenLevel(maxOxygenLevel);

        Slider_Oxygen.interactable = false;
        Slider_Oxygen.maxValue = maxOxygenLevel;
        Slider_Oxygen.value = oxygenLevel;
        Slider_Oxygen.onValueChanged.AddListener((value) => oxygenLevel = value);
    }

    private void SetOxygenLevel(float value)
    {
        Slider_Oxygen.value = value;
    }

    public bool IncreaseOxygenLevelByValue(float value)
    {
        Slider_Oxygen.value += value;
        return oxygenLevel < maxOxygenLevel;
    }
}
