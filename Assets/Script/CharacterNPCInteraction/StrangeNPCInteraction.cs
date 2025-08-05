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
    [SerializeField]
    bool WalletFirstTime = true;
    public Interaction interaction;
    GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        interaction = GetComponentInChildren<Interaction>();
        ExeclaimationMark.SetActive(false);
        if (gameManager.stranger == 3)
        {
            this.gameObject.SetActive(false);
        }
        if (gameManager.wife == 1 && gameManager.coworker == 1 && gameManager.wallet == 0 && DialogueList1.activeSelf == false)
        {
            DialogueList.SetActive(false);
            DialogueList1.SetActive(true);
            DialogueList2.SetActive(false);
            RefreshInteraction();
        }
    }

    public void RefreshInteraction()
    {
        interaction = GetComponentInChildren<Interaction>();
        if (interaction.Jumscare == true)
        {
            interaction.dialogmanager.AfterLastDialogue.AddListener(StartJS);
        }
        else if (interaction.Jumscare == false)
        {
            interaction.dialogmanager.AfterLastDialogue.RemoveListener(StartJS);
        }
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
                if (gameManager.wife == 1 && gameManager.coworker == 1 && gameManager.wallet == 0 && gameManager.stranger == 0)
                {
                    gameManager.stranger = 1;

                }
                if (gameManager.wallet != 0)
                {
                    WalletFirstTime = false;
                }
            }
            if (gameManager.wife == 1 && gameManager.coworker == 1 &&  gameManager.stranger == 2 && gameManager.wallet == 1 && WalletFirstTime == true && DialogueList2.activeSelf == false)
            {
                DialogueList.SetActive(false);
                DialogueList1.SetActive(false);
                DialogueList2.SetActive(true);
                RefreshInteraction();
            }

        }
        else
            ExeclaimationMark.SetActive(false);

    }

    void StartJS()
    {
        StartCoroutine(JS());
    }

    IEnumerator JS()
    {
        Jumscare.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        gameManager.stranger = 3;
        Jumscare.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
