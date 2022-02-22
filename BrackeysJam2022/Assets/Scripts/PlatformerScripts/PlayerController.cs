using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private JumpHandler jump;
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private GroundedCheck ground;
    [SerializeField] private MovementHandler move;
    private bool grounded;

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = ground.CheckGrounded();

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
    }
}
