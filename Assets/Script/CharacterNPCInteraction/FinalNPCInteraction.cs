using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalNPCInteraction : MonoBehaviour
{
    public GameObject DialogueObject;
    public GameObject ExeclaimationMark;


    private bool insideTrigger;
    bool firstTime = true;
    public Interaction interaction;
    GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        interaction = GetComponentInChildren<Interaction>();
        ExeclaimationMark.SetActive(false);
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
                firstTime = false;
            }
        }
        else
            ExeclaimationMark.SetActive(false);

    }
}
