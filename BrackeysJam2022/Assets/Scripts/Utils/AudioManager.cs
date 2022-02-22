using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public void Play() {
        Debug.Log("Play sound");
    }
}
