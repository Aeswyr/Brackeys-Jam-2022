using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObj : MonoBehaviour
{
    [SerializeField] private UnityEvent onClickedEvent;

    public void OnClicked()
    {
        onClickedEvent.Invoke();
    }
}
