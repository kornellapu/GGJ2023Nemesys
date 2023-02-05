using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
using UnityEngine.Events;
using System;

public class Lever : MonoBehaviour, IInteractable
{
	[Header("Trigger Event")]
	[SerializeField] UnityEvent Event;
	[SerializeField] GameObject InteractButton;
	[SerializeField] GameObject[] Lights;
	[SerializeField] Material[] Materials;

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
		if (Event != null)
			Event.Invoke();
		SwapMaterial();
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
}
