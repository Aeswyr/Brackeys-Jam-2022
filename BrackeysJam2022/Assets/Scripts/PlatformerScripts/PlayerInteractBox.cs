using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractBox : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private Collider2D overlap;
    void OnTriggerEnter2D(Collider2D other) {
        player.SetInteractPrompt(true);
        overlap = other;
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other != overlap)
            return;
        player.SetInteractPrompt(false);
        overlap = null;
    }

    private void OnTriggerStay2D(Collider2D other) {
        overlap = other;
    }

    public void TryInteract() {
        if (overlap == null)
            return;
        if (overlap.gameObject.TryGetComponent(out InteractableObj obj))
            obj.OnInteract();
    }
}
