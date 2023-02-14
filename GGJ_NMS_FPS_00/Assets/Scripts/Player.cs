using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("References/UI")]
    [SerializeField] RectTransform Rect_Oxygen;
    [SerializeField] Slider Slider_Oxygen;
	[SerializeField] TextMeshProUGUI Text_OxygenPercent;

	[Header("References/Variables")]
    [SerializeField] int maxOxygenLevel = 100;

    [Range(0, 100)]
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
		Text_OxygenPercent.text = $"{Slider_Oxygen.value} %";
		Slider_Oxygen.onValueChanged.AddListener((value) => oxygenLevel = value);
    }

    private void SetOxygenLevel(float value)
    {
        Slider_Oxygen.value = value;
	}

    public bool IncreaseOxygenLevelByValue(float value)
    {
        Slider_Oxygen.value += value;
		Text_OxygenPercent.text = $"{Math.Floor(Slider_Oxygen.value)} %";
		return oxygenLevel < maxOxygenLevel && oxygenLevel > 0;
    }
}
