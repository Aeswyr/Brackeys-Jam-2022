using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float speed;

    public void SpawnArrow(float dir) {
        dir = dir / Mathf.Abs(dir);
        GameObject arr = Instantiate(arrow, GameMaster.Instance.GetCurrentLevel().GetLevelObjects().transform);
        arr.transform.position = this.transform.position;
        arr.GetComponent<Rigidbody2D>().velocity = dir * speed * Vector2.right;
        if (dir < 0)
            arr.GetComponent<SpriteRenderer>().flipX = true;
    }
}
