using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private Collider2D hitbox;
    
    private void OnTriggerEnter2D(Collider2D other) {
        rbody.velocity = Vector2.zero;
        rbody.gravityScale = 0;
        hitbox.enabled = false;
    }
}
