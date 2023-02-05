using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button Button_NewGame;
    [SerializeField] Button Button_Controls;
    [SerializeField] Button Button_Credits;
    [SerializeField] Button Button_Quit;

    void Start()
    {
        Button_NewGame.onClick.AddListener(() => SceneManager.LoadScene("FinalScene"));
		//Button_Controls.onClick.AddListener(() => SceneManager.LoadScene("FinalScene"));
		//Button_Credits.onClick.AddListener(() => SceneManager.LoadScene("FinalScene"));
		Button_Quit.onClick.AddListener(() => Application.Quit());
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
