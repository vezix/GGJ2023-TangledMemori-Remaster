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
    public GameObject LockedPhone;
    public SimpleCharacterController PController;
    public string scene;
    public GameObject ExeclaimationMark;
    public GameObject ButtonBlocker;
    private string Answer = "8562";
    bool insideTrigger = false;
    bool couroutineRunning = false;
    public GameObject DialogueObject;
    public Interaction interaction;

    public GameObject ghost;
    bool ghostjs=false;

    public GameObject wife;
    bool wifejs = false;

    public GameObject portal;
    public GameObject Blackscreen;

    public GameObject[] ChildObject;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ExeclaimationMark.SetActive(false);
        //interaction = GetComponentInChildren<Interaction>();
        if (gameManager.coworker < 3)
        {
            this.gameObject.GetComponent<NPCInteraction>().enabled = true;
            this.gameObject.GetComponent<Keypad>().enabled = false;
        }
        else if (gameManager.coworker == 3)
        {

            if (gameManager.wife == 3)
            {
                this.gameObject.GetComponent<NPCInteraction>().enabled = false;
                this.gameObject.GetComponent<Keypad>().enabled = false;
            }
            else
            {
                this.gameObject.GetComponent<NPCInteraction>().enabled = false;
                this.gameObject.GetComponent<Keypad>().enabled = true;
                ghost.SetActive(true);
                ghostjs = true;
                StartCoroutine("JS");
            }
        }
        else
        {
            this.gameObject.GetComponent<NPCInteraction>().enabled = false;
            this.gameObject.GetComponent<Keypad>().enabled = false;
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
            interaction.dialogmanager.AfterLastDialogue.AddListener(DialogueJS);
            this.gameObject.GetComponent<Keypad>().enabled = false;
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
        gameManager.wife = 3;
    }

    void DialogueJS()
    {
        interaction.dialogmanager.AfterLastDialogue.RemoveListener(DialogueJS);
        portal.SetActive(false);
        foreach (GameObject obj in ChildObject)
        {
            obj.GetComponent<BoxCollider2D>().enabled = false;
        }
        StartCoroutine("JS2");
    }

    IEnumerator JS()
    {
        while (ghostjs == true)
        {
            ghost.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.01f));
            ghost.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.01f));
        }
    }
    IEnumerator JS1()
    {
        while (wifejs == true)
        {
            wife.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.01f));
            wife.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.01f));
        }
    }

    IEnumerator JS2()
    {
        wifejs = true;
        StartCoroutine("JS1");
        yield return new WaitForSeconds(3f);
        wifejs = false;
        ghostjs = false;
        Blackscreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        //portal.SetActive(true);
        SceneManager.LoadScene(scene);
    }
}
