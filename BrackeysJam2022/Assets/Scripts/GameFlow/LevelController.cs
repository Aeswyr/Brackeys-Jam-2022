using UnityEngine;

public class LevelController : MonoBehaviour {
    [SerializeField] private LevelExit[] exits;

    public LevelExit GetExit(int index) {
        if (index >= exits.Length || index < 0) {
            Debug.LogError($"Tried to access level exit at index {index}");
            return null;
        }
        return exits[index];
    }
}