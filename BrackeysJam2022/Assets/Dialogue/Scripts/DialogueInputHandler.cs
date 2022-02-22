using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInputHandler : Singleton<DialogueInputHandler>
{
    private bool unused = true;

    private void FixedUpdate()
    {
        unused = true;
    }

    public bool InteractPressedDown()
    {
        if(unused && InputHandler.Instance.interact.pressed)
        {
            unused = false;
            return true;
        }

        return false;
    }
}
