using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

    public GameObject DialogueObject;
    private bool insideTrigger;
    public Interaction interaction;

    public void Start()
    {
        //NOT FINAL, create a script where when you 
        interaction = GetComponentInChildren<Interaction>();
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                interaction.DialogueStart();
            }
        }

    }

}
