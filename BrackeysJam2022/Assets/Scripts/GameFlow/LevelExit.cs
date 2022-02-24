using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{   
    [SerializeField] private int toLevel;
    [SerializeField] private int atExit;
    public void GotoLevel() {
        LevelController ctrl = GameMaster.Instance.GotoLevel(toLevel);
        GameMaster.Instance.GetPlayer().transform.position = ctrl.GetExit(atExit).transform.position;
    }
}
