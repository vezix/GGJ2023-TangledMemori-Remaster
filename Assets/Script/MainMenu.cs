using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.wife = 0;
        gameManager.coworker = 0;
        gameManager.stranger = 0;
        gameManager.wallet = 0;
        gameManager.Hobject = 0;
        gameManager.Oobject = 0;
        gameManager.TrainEnter = 0;
        gameManager.tuto = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SceneTuto");
        }
    }
}
