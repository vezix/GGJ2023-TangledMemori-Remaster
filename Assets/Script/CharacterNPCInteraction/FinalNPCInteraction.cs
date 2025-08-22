using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalNPCInteraction : MonoBehaviour
{
    public GameObject DialogueObject;
    public GameObject ExeclaimationMark;


    private bool insideTrigger;
    public Interaction interaction;
    GameManager gameManager;

    public string scene;
    public GameObject Jumscare;
    public GameObject GameLogo;
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
                interaction.dialogmanager.AfterLastDialogue.AddListener(StartJS);
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
        yield return new WaitForSeconds(3.0f);
        Jumscare.gameObject.SetActive(false);
        GameLogo.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(scene);
        //Jumscare.gameObject.SetActive(false);
    }
}
