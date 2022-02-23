using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private LayerMask clickableLayer;
    [SerializeField] private float mouseSpeed;
    [SerializeField] private Canvas mouseCanvas;

    private Camera cam;

    private void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }


    public void Update()
    {
        //Move mouse
        Vector2 mouseDelta = InputHandler.Instance.mouseDelta;
        MoveMouse(mouseDelta);
    }

    public void MoveMouse(Vector2 amountToMove)
    {
        float halfCanvWidth = mouseCanvas.renderingDisplaySize.x/2f;
        float halfCanvHeight = mouseCanvas.renderingDisplaySize.y/2f;

        float posX = transform.localPosition.x + amountToMove.x;
        posX = Mathf.Clamp(posX,  -halfCanvWidth, halfCanvWidth);

        float posY = transform.localPosition.y + amountToMove.y;
        posY = Mathf.Clamp(posY, -halfCanvHeight, halfCanvHeight);

        transform.localPosition = new Vector3(posX, posY, 0);
    }

    public void FixedUpdate()
    {
        if(InputHandler.Instance.mouseLeft.pressed)
        {
            OnClickMouse();
        }
    }

    public void OnClickMouse()
    {
        Collider2D clickedObj = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(transform.position), clickableLayer);
        if (clickedObj != null)
        {
            clickedObj.GetComponent<ClickableObj>().OnClicked();
        }
    }
}
