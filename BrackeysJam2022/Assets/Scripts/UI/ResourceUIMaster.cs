using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceUIMaster : Singleton<ResourceUIMaster>
{
    int bombs;
    int keys;
    [SerializeField] private TextMeshProUGUI bombText;
    [SerializeField] private TextMeshProUGUI keyText;

    public bool UseBomb() {
        if (bombs < 1)
            return false;
        bombs--;
        SetBombUI();
        return true;
    }
    public void AddBomb() {
        bombs++;
        SetBombUI();
    }

    private void SetBombUI() {
        if (bombs < 10)
            bombText.text = $"0{bombs}";
        else
            bombText.text = bombs.ToString();
    }

    public bool UseKey() {
        if (keys < 1)
            return true;
        keys--;
        SetKeyUI();
        return true;
    }

    public void AddKey() {
        keys++;
        SetKeyUI();
    }

    private void SetKeyUI() {
        if (keys < 10)
            keyText.text = $"0{keys}";
        else
            keyText.text = keys.ToString();
    }
}
