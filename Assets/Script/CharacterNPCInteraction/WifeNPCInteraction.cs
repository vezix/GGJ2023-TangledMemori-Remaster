using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifeNPCInteraction : MonoBehaviour
{
    public GameObject DialogueList;
    public GameObject DialogueList1;
    public GameObject DialogueObject;
    public GameObject ExeclaimationMark;


    private bool insideTrigger;
    public Interaction interaction;
    GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        interaction = GetComponentInChildren<Interaction>();
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
        if ((insideTrigger == true) && (DialogueObject.activeSelf == false))
        {
            ExeclaimationMark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                interaction.DialogueStart();
                gameManager.wife = 1;
            }
            if (gameManager.coworker != 0 && DialogueList1.activeSelf == false)
            {
                DialogueList.SetActive(false);
                DialogueList1.SetActive(true);
                RefreshInteraction();
            }
        }
        else
            ExeclaimationMark.SetActive(false);

    }
}
