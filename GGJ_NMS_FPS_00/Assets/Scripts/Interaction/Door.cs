using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
using System;

[RequireComponent(typeof(BoxCollider))]
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] bool isOpen = false;
    public bool isInteracting = false;
    public void Start()
    {
        Init();   
    }

    private void Init()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    public void Interact()
    {
        if (isInteracting)
            return;
        Debug.Log($"Interacted with {gameObject.name}");
        Toggle(!isOpen);
    }

    public void Cancel()
    {
        if (!isInteracting)
            return;

        Debug.Log($"Cancel interaction with {gameObject.name}");
    }

    public void Toggle(bool state)
    {
        isOpen = state;
    }
}
