using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

    public GameObject DialogueObject;
    private bool insideTrigger;
    public Interaction interaction;
    public GameObject ExeclaimationMark;
    GameManager gameManager;

    public bool DeactiveAfterDone=false;

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
                if (interaction.HomeObject == true)
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
                if (interaction.OfficeObject == true)
                {
                    if (gameManager.Oobject < 3)
                    {
                        if (FirstTimeInteract == true)
                        {
                            FirstTimeInteract = false;
                            gameManager.Oobject += 1;
                        }
                    }
                }
                if (DeactiveAfterDone == true)
                {
                    interaction.dialogmanager.AfterLastDialogue.AddListener(CloseTheDamnUI);
                }
                interaction.DialogueStart();
            }
        }
        else
            ExeclaimationMark.SetActive(false);

    }

    void CloseTheDamnUI()
    {
        this.gameObject.GetComponent<NPCInteraction>().enabled = false;
    }

}
