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
    [SerializeField] private ArrowHandler arrows;
    private bool grounded, inputLock = false;
    private float facing = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = ground.CheckGrounded();



        // INPUTS
        if (!inputLock) {

            if (InputHandler.Instance.walk.released)
                move.StartDeceleration();
            if (InputHandler.Instance.walk.pressed)
                move.StartAcceleration(InputHandler.Instance.dir.x / Mathf.Abs(InputHandler.Instance.dir.x));
            if (InputHandler.Instance.walk.down) {
                move.UpdateMovement(InputHandler.Instance.dir.x / Mathf.Abs(InputHandler.Instance.dir.x));
                facing = InputHandler.Instance.dir.x;
            }

            if (InputHandler.Instance.jump.pressed && grounded) {
                jump.StartJump();
                AudioManager.Instance.Play();
            }

            if (InputHandler.Instance.interact.pressed) {
                interactBox.TryInteract();
            }

            if (InputHandler.Instance.special.pressed) {
                arrows.SpawnArrow(facing);
            }

            if (InputHandler.Instance.bomb.pressed) {
                ResourceUIMaster.Instance.AddBomb();
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
            move.CancelMovement();
            jump.ForceLanding();
        }
    }

    public bool Grounded => grounded;
}
