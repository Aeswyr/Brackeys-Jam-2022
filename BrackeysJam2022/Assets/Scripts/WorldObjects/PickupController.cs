using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public void PickupBomb() {
        ResourceUIMaster.Instance.AddBomb();
        Destroy(gameObject);
    }
}
