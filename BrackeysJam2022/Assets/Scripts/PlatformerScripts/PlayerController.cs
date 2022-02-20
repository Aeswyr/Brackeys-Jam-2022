using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private InputHandler input;
    [SerializeField] private JumpHandler jump;
    [SerializeField] private Rigidbody2D rbody;

    void Awake() {
       jump.LinkInputs(input); 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (input.dir != 0) {
            rbody.velocity = new Vector2(speed * input.dir, rbody.velocity.y);
        }

        if (input.jump.pressed) {
            jump.StartJump();
        }
    }
}
