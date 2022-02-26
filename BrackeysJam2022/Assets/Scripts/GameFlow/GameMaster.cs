using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singleton<GameMaster>
{
    [SerializeField] private PrefabList levelMasterList;
    private LevelController currentLevel;
    private PlayerController player;

    void Start() {
        currentLevel = FindObjectOfType<LevelController>();
        player = FindObjectOfType<PlayerController>();
    }
    public LevelController GotoLevel(int index) {
        GameObject level = levelMasterList.Get(index);
        if (level == null)
            return null;

        Destroy(currentLevel.gameObject);
        currentLevel = Instantiate(level).GetComponent<LevelController>();
        return currentLevel;
    }

    public PlayerController GetPlayer() {
        return player;
    }

    public void SetInputLock(bool state) {
        player.SetInputLock(state);
    }

    public LevelController GetCurrentLevel() {
        return currentLevel;
    }
}
