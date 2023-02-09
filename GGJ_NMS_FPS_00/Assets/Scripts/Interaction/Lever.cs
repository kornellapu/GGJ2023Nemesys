using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
using UnityEngine.Events;
using System;

public class Lever : MonoBehaviour, IInteractable
{
	[Header("Trigger Event")]
	[SerializeField] UnityEvent[] Events;
	[SerializeField] GameObject InteractButton;
	[SerializeField] GameObject[] Lights;
	[SerializeField] Material[] Materials;
	[SerializeField] bool disableAfterInteract = false;

	public bool isON { get; private set; }
	public bool Interactable = true;

	private void Start()
	{
		isON = false;
		SwapMaterial();
		gameObject.layer = LayerMask.NameToLayer("Interactable");
	}

	public void Interact()
	{
		if (!Interactable)
			return;

		Toggle(!isON);
		if (Events.Length != 0)
        {
			for(int i = 0; i < Events.Length; i++)
            {
				if(Events[i] != null)
                {
					Events[i].Invoke();
                }
            }
        }
		SwapMaterial();

		if (disableAfterInteract)
			Interactable = false;
	}

	private void SwapMaterial()
	{
		InteractButton.GetComponent<MeshRenderer>().material = Materials[Convert.ToInt32(isON)];
		Lights[Convert.ToInt32(isON)].SetActive(true);
		Lights[Convert.ToInt32(!isON)].SetActive(false);
	}

	public void ActivateLever()
	{
		Interactable = true;
		Toggle(!isON);
		SwapMaterial();
	}

	public void Cancel()
	{
		if (!Interactable)
			return;
	}

	public void Toggle(bool state)
	{
		isON = state;
	}

	public void Hover()
	{

	}

	public void CancelHover()
	{

	}
}
