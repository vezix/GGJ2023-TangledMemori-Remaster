using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifeNPCInteraction : MonoBehaviour
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

        if (gameManager.wife < 1)
        {
            foreach (GameObject obj in ChildObject)
            {
                obj.GetComponent<BoxCollider2D>().enabled = false; 
            }
        }
        if (gameManager.wife == 1)
        {
            interaction.SetInteracted(true);
        }
        if (gameManager.wife == 2)
        {
            DialogueList.SetActive(false);
            DialogueList1.SetActive(true);
            RefreshInteraction();
            interaction.SetInteracted(true);
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
                if (gameManager.wife == 0)
                {
                    gameManager.wife = 1;
                }
                if (gameManager.wife == 1  && gameManager.Hobject == 3)
                {
                    gameManager.wife = 2;
                }
                interaction.DialogueStart();
                //firstTime = false;
            }
            if (gameManager.Hobject >= 3)
            {
                DialogueList.SetActive(false);
                DialogueList1.SetActive(true);
                RefreshInteraction();
            }
            if (gameManager.wife == 1)
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
