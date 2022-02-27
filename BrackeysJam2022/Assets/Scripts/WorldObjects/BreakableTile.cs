using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakableTile : MonoBehaviour
{
    bool destroyed = false;
    private void OnTriggerEnter2D(Collider2D other) {
        destroyed = true;
    }

    void FixedUpdate() {
        if (destroyed) {
            Tilemap map = GameMaster.Instance.GetCurrentLevel().GetTilemap();
            map.SetTile(map.WorldToCell(transform.position), null);
        }
    }
}
