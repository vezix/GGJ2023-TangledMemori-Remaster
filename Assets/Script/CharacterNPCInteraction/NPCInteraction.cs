using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

    public GameObject DialogueObject;
    private bool insideTrigger;
    public Interaction interaction;
    public GameObject ExeclaimationMark;
    public bool houseObject;
    GameManager gameManager;

    bool FirstTimeInteract = true;

    public void Start()
    {
        //NOT FINAL, create a script where when you 
        //interaction = GetComponentInChildren<Interaction>();
        gameManager = FindObjectOfType<GameManager>();
        ExeclaimationMark.SetActive(false);
    }

    public void RefreshInteraction()
    {
        interaction = GetComponentInChildren<Interaction>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player can chat with npc");
            insideTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Byebye npc");
            insideTrigger = false;
        }
    }

    void Update()
    {
        if ((insideTrigger == true) && (!DialogueObject.activeSelf))
        {
            ExeclaimationMark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (houseObject == true)
                {
                    if (gameManager.Hobject < 3)
                    {
                        if (FirstTimeInteract == true)
                        {
                            FirstTimeInteract = false;
                            gameManager.Hobject += 1;
                        }
                    }
                }
                interaction.DialogueStart();
            }
        }
        else
            ExeclaimationMark.SetActive(false);

    }

}
