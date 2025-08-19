using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    GameManager gameManager;
    private bool insideTrigger;
    public GameObject ExeclaimationMark;
    public GameObject DialogueObject;
    public Interaction interaction;
    public GameObject Chang;
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager.stranger == 3 && gameManager.coworker < 3 )
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player can pickup object");
            insideTrigger = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Byebye object");
            insideTrigger = false;
        }
    }

    void Update()
    {


        if (insideTrigger == true)
        {
            ExeclaimationMark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                interaction.DialogueStart();
                gameManager.coworker = 3;
                ExeclaimationMark.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
        else
            ExeclaimationMark.SetActive(false);

    }
}
