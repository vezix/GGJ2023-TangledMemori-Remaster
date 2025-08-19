using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoWorkerNPCInteraction : MonoBehaviour
{
    public GameObject DialogueList;
    public GameObject DialogueList1;
    public GameObject DialogueObject;
    public GameObject ExeclaimationMark;

    public GameObject[] ChildObject;

    private bool insideTrigger;
    //bool firstTime = true;
    bool ChildObjectFirsttime = true;
    public Interaction interaction;
    GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        interaction = GetComponentInChildren<Interaction>();
        ExeclaimationMark.SetActive(false);

        if (gameManager.coworker < 1 )
        {
            foreach (GameObject obj in ChildObject)
            {
                obj.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (gameManager.coworker == 1 )
        {
            interaction.SetInteracted(true);
        }
        if (gameManager.coworker == 2)
        {
            DialogueList.SetActive(false);
            DialogueList1.SetActive(true);
            RefreshInteraction();
            interaction.SetInteracted(true);
        }
        if (gameManager.stranger >= 3)
        {
            foreach (GameObject obj in ChildObject)
            {
                obj.GetComponent<BoxCollider2D>().enabled = false;
            }
                this.gameObject.SetActive(false);
        }

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
        if ((insideTrigger == true) && (DialogueObject.activeSelf == false))
        {
            ExeclaimationMark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (gameManager.coworker == 0)
                {
                    gameManager.coworker = 1;
                }
                if (gameManager.coworker == 1 && gameManager.Oobject == 3)
                {
                    gameManager.coworker = 2;
                }
                interaction.DialogueStart();
                //firstTime = false;
            }
            if (gameManager.Oobject >= 3)
            {
                DialogueList.SetActive(false);
                DialogueList1.SetActive(true);
                RefreshInteraction();
            }
            if (gameManager.coworker == 1)
            {
                if (ChildObjectFirsttime == true)
                {
                    foreach (GameObject obj in ChildObject)
                    {
                        obj.GetComponent<BoxCollider2D>().enabled = true;
                    }
                    ChildObjectFirsttime = false;
                }
            }
        }
        else
            ExeclaimationMark.SetActive(false);

    }
}
