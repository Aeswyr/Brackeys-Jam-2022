using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private GameObject explodePrefab;
    [SerializeField] private float delay;
    private float timestamp;

    void Start() {
        timestamp = Time.time + delay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > timestamp) {
            Destroy(this.gameObject);
            GameObject obj = Instantiate(explodePrefab, GameMaster.Instance.GetCurrentLevel().GetLevelObjects().transform);
            obj.transform.position = this.transform.position;
        }
    }
}
