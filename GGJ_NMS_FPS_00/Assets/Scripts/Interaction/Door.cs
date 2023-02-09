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
        Toggle(!isOpen);

        //todo: animation
    }

    public void Cancel()
    {
        if (!isInteracting)
            return;
    }

    public void Toggle(bool state)
    {
        isOpen = state;
    }

    public void Hover()
    {

    }

    public void CancelHover()
    {

    }
}
