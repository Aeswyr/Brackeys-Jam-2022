using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelController : MonoBehaviour {
    [SerializeField] private LevelExit[] exits;
    [SerializeField] private GameObject levelObjects;
    [SerializeField] private Tilemap collidables;

    public LevelExit GetExit(int index) {
        if (index >= exits.Length || index < 0) {
            Debug.LogError($"Tried to access level exit at index {index}");
            return null;
        }
        return exits[index];
    }

    public GameObject GetLevelObjects() {
        return levelObjects;
    }

    public Tilemap GetTilemap() {
        return collidables;
    }
}