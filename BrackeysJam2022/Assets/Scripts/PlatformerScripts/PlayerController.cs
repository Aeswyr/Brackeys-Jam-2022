using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private JumpHandler jump;
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private GroundedCheck ground;
    [SerializeField] private MovementHandler move;
    [SerializeField] private GameObject interactPrompt;
    [SerializeField] private PlayerInteractBox interactBox;
    private bool grounded, inputLock = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = ground.CheckGrounded();



        // INPUTS
        if (!inputLock) {
            if (InputHandler.Instance.move.released)
                move.StartDeceleration();
            if (InputHandler.Instance.move.pressed)
                move.StartAcceleration(InputHandler.Instance.dir.x);
            if (InputHandler.Instance.dir.x != 0) {
                move.UpdateMovement(InputHandler.Instance.dir.x);
            }

            if (InputHandler.Instance.jump.pressed && grounded) {
                jump.StartJump();
                AudioManager.Instance.Play();
            }

            if (InputHandler.Instance.interact.pressed) {
                interactBox.TryInteract();
            }

            if (InputHandler.Instance.special.pressed) {
                Debug.Log("pew");
            }
        }

        // END INPUTS
    }

    public void SetInteractPrompt(bool prompt) {
        interactPrompt.SetActive(prompt);
    }

    public void SetInputLock(bool state) {
        inputLock = state;
        if (state) {
            rbody.velocity = Vector2.zero;
        }
    }
}
