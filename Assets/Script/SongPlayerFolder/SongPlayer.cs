using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public string BGSong;
    void Start()
    {
        FindObjectOfType<AudioManager>().stopAllBG();
        FindObjectOfType<AudioManager>().PlayBG(BGSong);
    }
}

