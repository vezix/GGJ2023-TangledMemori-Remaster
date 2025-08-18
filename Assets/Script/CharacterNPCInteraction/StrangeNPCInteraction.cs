using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StrangeNPCInteraction : MonoBehaviour
{
    public GameObject DialogueList;
    public GameObject DialogueList1;
    public GameObject DialogueListEnter;
    public GameObject DialogueObject;
    public GameObject ExeclaimationMark;
    public GameObject Jumscare;
    public GameObject ClockInteraction;
    public string scene;

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

        if (gameManager.TrainEnter == 0)
        {
            DialogueListEnter.SetActive(true);
            DialogueList.SetActive(false);
            DialogueList1.SetActive(false);
            RefreshInteraction();
            interaction.DialogueStart();
            gameManager.TrainEnter = 1;
            ClockInteraction.SetActive(false);

        }
        else if (gameManager.wife > 0 && gameManager.coworker > 0 && gameManager.TrainEnter > 0)
        {
            ClockInteraction.SetActive(true);
        }

        if (gameManager.stranger == 2)
        {
            ClockInteraction.SetActive(false);
            this.gameObject.SetActive(false);
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
                if (gameManager.stranger == 0) 
                {
                    gameManager.stranger = 1;
                    DialogueListEnter.SetActive(false);
                    DialogueList1.SetActive(false);
                    DialogueList.SetActive(true);
                    RefreshInteraction();

                }
                if (gameManager.wallet == 1 && WalletFirstTime == true)
                {
                    DialogueList.SetActive(false);
                    DialogueList1.SetActive(true);
                    RefreshInteraction();
                    WalletFirstTime = false;
                    gameManager.wallet = 2;
                }
                interaction.DialogueStart();
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
        gameManager.stranger = 2;
        SceneManager.LoadScene(scene);
        //Jumscare.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
