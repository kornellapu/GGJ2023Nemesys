using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
using System;

[RequireComponent(typeof(BoxCollider))]
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] bool isOpen = false;
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
        Debug.Log($"Interacted with {gameObject.name}");
        Toggle(!isOpen);
    }

    public void Toggle(bool state)
    {
        isOpen = state;
    }

}
