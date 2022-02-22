using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInputHandler : Singleton<DialogueInputHandler>
{
    private bool interactPressedDown;

    private void FixedUpdate()
    {
        interactPressedDown = false;

        if(InputHandler.Instance.interact.pressed)
        {
            interactPressedDown = true;
        }
    }

    public bool InteractPressedDown()
    {
        if(interactPressedDown)
        {
            interactPressedDown = false;
            return true;
        }

        return false;
    }
}
