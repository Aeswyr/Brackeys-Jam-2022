using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetController : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    private void OnTriggerEnter2D(Collider2D other) {
        action.Invoke();
    }
}
