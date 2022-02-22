using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputHandler input;
    [SerializeField] private JumpHandler jump;
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private GroundedCheck ground;
    [SerializeField] private MovementHandler move;
    private bool grounded;

    void Awake() {
       jump.LinkInputs(input); 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = ground.CheckGrounded();

        if (input.move.released)
            move.StartDeceleration();
        if (input.move.pressed)
            move.StartAcceleration(input.dir);
        if (input.dir != 0) {
            move.UpdateMovement(input.dir);
        }

        if (input.jump.pressed && grounded) {
            jump.StartJump();
            AudioManager.Instance.Play();
        }
    }
}
