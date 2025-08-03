using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StrangeNPCInteraction : MonoBehaviour
{
    public GameObject DialogueList;
    public GameObject DialogueList1;
    public GameObject DialogueList2;
    public GameObject DialogueObject;
    public GameObject ExeclaimationMark;
    public GameObject Jumscare;

    private bool insideTrigger;
    bool firstTime = true;
    [SerializeField]
    bool WalletFirstTime = true;
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
        if ((insideTrigger == true) && (DialogueObject.activeSelf == false) && (Jumscare.activeSelf == false))
        {
            ExeclaimationMark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                interaction.DialogueStart();
                if (gameManager.wallet != 0)
                {
                    WalletFirstTime = false;
                }
                gameManager.stranger = 1;
                firstTime = false;
            }
            if (gameManager.wife != 0 && gameManager.coworker !=0 && DialogueList1.activeSelf == false)
            {
                DialogueList.SetActive(false);
                DialogueList1.SetActive(true);
                DialogueList2.SetActive(false);
                RefreshInteraction();
            }
            if (gameManager.wallet !=0 && WalletFirstTime == true && DialogueList1.activeSelf == false)
            {
                DialogueList.SetActive(false);
                DialogueList1.SetActive(false);
                DialogueList2.SetActive(true);
                RefreshInteraction();
            }
            else if (gameManager.wife == 0 && gameManager.coworker == 0 && WalletFirstTime == false && DialogueList1.activeSelf == false)
            {
                DialogueList.SetActive(true);
                DialogueList1.SetActive(false);
                DialogueList2.SetActive(false);
                RefreshInteraction();
            }
            if (gameManager.stranger == 3)
            {
                this.gameObject.SetActive(false);   
            }

        }
        else
            ExeclaimationMark.SetActive(false);

    }
}
