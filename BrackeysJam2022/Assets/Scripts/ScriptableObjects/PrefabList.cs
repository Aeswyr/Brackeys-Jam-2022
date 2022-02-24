using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabList", menuName = "BrackeysJam2022/PrefabList", order = 0)]
public class PrefabList : ScriptableObject {
    [SerializeField] private GameObject[] objects;

    public GameObject Get(int index) {
        if (index >= objects.Length || index < 0) {
            Debug.LogError($"Invalid object index access: {index}");
            return null;
        }
        return objects[index];
    }
}
