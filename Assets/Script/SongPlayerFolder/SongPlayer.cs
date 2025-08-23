using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public string BGSong;
    public string BGSong1;
    GameManager gameManager;

    public bool TreeRoom;
    public bool Home;
    public bool Office;
    public bool Train;
    public bool basic;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (TreeRoom == true)
        {
            if (gameManager.tuto == 0)
            {
                FindObjectOfType<AudioManager>().stopAllBG();
                FindObjectOfType<AudioManager>().PlayBG(BGSong);
                gameManager.tuto = 1;

            }
            if (gameManager.tuto == 2)
            {
                FindObjectOfType<AudioManager>().stopAllBG();
                FindObjectOfType<AudioManager>().PlayBG(BGSong);
            }
        }
        if (Home == true )
        {
            gameManager.tuto = 2;
            if (gameManager.coworker == 3)
            {
                FindObjectOfType<AudioManager>().stopAllBG();
                if (gameManager.wife != 3)
                {
                    FindObjectOfType<AudioManager>().PlayBG(BGSong1);
                }
            }
            else
            {
                FindObjectOfType<AudioManager>().stopAllBG();
                FindObjectOfType<AudioManager>().PlayBG(BGSong);
            }
        }
        if (Office == true)
        {
            gameManager.tuto = 2;
            if (gameManager.stranger == 3)
            {
                FindObjectOfType<AudioManager>().stopAllBG();
            }
            else if (gameManager.stranger == 2)
            {
                FindObjectOfType<AudioManager>().stopAllBG();
                FindObjectOfType<AudioManager>().PlayBG(BGSong1);
            }
            else
            {
                FindObjectOfType<AudioManager>().stopAllBG();
                FindObjectOfType<AudioManager>().PlayBG(BGSong);
            }
        }
        if (Train == true)
        {
            gameManager.tuto = 2;
            if (gameManager.wallet == 2)
            {
                FindObjectOfType<AudioManager>().stopAllBG();
            }
            else
            {
                FindObjectOfType<AudioManager>().stopAllBG();
                FindObjectOfType<AudioManager>().PlayBG(BGSong);
            }

        }
        if (basic == true)
        {
            FindObjectOfType<AudioManager>().stopAllBG();
            FindObjectOfType<AudioManager>().PlayBG(BGSong);
        }
    }
}

