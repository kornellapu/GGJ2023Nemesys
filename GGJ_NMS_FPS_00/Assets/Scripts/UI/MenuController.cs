using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button Button_Back;
    [SerializeField] Button Button_Credits;
	[SerializeField] Button Button_Controls;
	[SerializeField] RectTransform Rect_Menu;
	[SerializeField] RectTransform Rect_Credits;
	[SerializeField] RectTransform Rect_Controls;


	void Start()
    {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Button_Credits.onClick.AddListener(() => OpenCredits());
        Button_Controls.onClick.AddListener(() => OpenControls());
        Button_Back.onClick.AddListener(() => ActivateMenu());
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
			ActivateMenu();
	}

    private void OpenCredits()
    {
        Rect_Credits.gameObject.SetActive(true);
        Rect_Menu.gameObject.SetActive(false);
		Button_Back.gameObject.SetActive(true);
	}

	private void OpenControls()
	{
		Rect_Controls.gameObject.SetActive(true);
		Rect_Menu.gameObject.SetActive(false);
        Button_Back.gameObject.SetActive(true);
	}

    private void ActivateMenu()
    {
		Rect_Menu.gameObject.SetActive(true);
		Rect_Controls.gameObject.SetActive(false);
		Rect_Credits.gameObject.SetActive(false);
		Button_Back.gameObject.SetActive(false);
	}
}
