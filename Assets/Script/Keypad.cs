using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] private TextMeshProUGUI Ans;
    public GameObject Phone;
    public SimpleCharacterController PController;
    public string scene;
    public GameObject ExeclaimationMark;
    public GameObject ButtonBlocker;
    private string Answer = "8562";
    bool insideTrigger = false;
    bool couroutineRunning = false;
    public GameObject DialogueObject;
    public Interaction interaction;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ExeclaimationMark.SetActive(false);
        interaction = GetComponentInChildren<Interaction>();
        if (gameManager.stranger != 1)
        {
            this.gameObject.GetComponent<Keypad>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<Keypad>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            Debug.Log("Can Interact With Phone");

            insideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Cannnot Interact With Phone");

            insideTrigger = false;
        }
    }

    private void Update()
    {
        if (insideTrigger == true && (!Phone.activeSelf) && (!DialogueObject.activeSelf))
        {
            ExeclaimationMark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Phone.SetActive(true);
                PController.enabled = false;
                ExeclaimationMark.SetActive(false);

            }
        }
        else if (insideTrigger == true && (Phone.activeSelf) && (couroutineRunning == false) )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Phone.SetActive(false);
                PController.enabled = true;
                ExeclaimationMark.SetActive(false);
            }
        }
        else
            ExeclaimationMark.SetActive(false);
    }


    public void Number(int number)
    {
        if (Ans.text.Length < 4)
        {
            Ans.text += number.ToString();
        }
    }

    public void Execute()
    {
        if(Ans.text == Answer)
        {
            Ans.text = "Correct";
            StartCoroutine("OneS");
            StartDialogue();
            this.gameObject.GetComponent<Keypad>().enabled = false;
            //SceneManager.LoadScene(scene);
        }
        else
        {
            Ans.text = "wrong pass";
            StartCoroutine("OneS");

        }
    }

    IEnumerator OneS()
    {
        ButtonBlocker.SetActive(true);
        couroutineRunning = true;
        yield return new WaitForSeconds(1.0f);
        Ans.text = "";
        ButtonBlocker.SetActive(false);
        couroutineRunning = false;
    }

    public void RefreshInteraction()
    {
        interaction = GetComponentInChildren<Interaction>();
    }

    public void StartDialogue()
    {
        Phone.SetActive(false);
        interaction.DialogueStart();
        gameManager.stranger = 2;
    }

}
