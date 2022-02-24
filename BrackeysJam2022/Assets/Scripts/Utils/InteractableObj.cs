using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObj : MonoBehaviour
{
    [SerializeField] private UnityEvent onInteractEvent;

    public void OnInteract() {
        onInteractEvent.Invoke();
    }
}
