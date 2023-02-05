using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
using UnityEngine.Events;

public class Lever : MonoBehaviour, IInteractable
{
	[Header("Trigger Event")]
	[SerializeField] UnityEvent Event;

	public bool isON { get; private set; }

	public void Interact()
	{
		Toggle(!isON);
		Event.Invoke();
	}

	public void Cancel()
	{
		
	}

	public void Toggle(bool state)
	{
		isON = state;
	}
}
