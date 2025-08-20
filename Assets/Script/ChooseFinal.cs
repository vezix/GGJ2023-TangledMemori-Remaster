using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ChooseFinal : MonoBehaviour
{
    private bool insideTrigger = false;
    public string scene;
    public GameObject TextObject;
    public TextMeshProUGUI Textbox;
    public SimpleCharacterController PController;
    public GameObject ExeclaimationMark;

    public Sprite Final1;
    public Sprite Final2;
    public Sprite Final3;

    public Image ButtonL;
    public Image ButtonC;
    public Image ButtonR;

    public GameObject ButtonBlocker;

    private bool FinalSelection = false;

    GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Can Interact");
            insideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bye bye");
            insideTrigger = false;
        }
    }

    private void Update()
    {
        if ((gameManager.wife == 3) && (gameManager.coworker == 3) && (gameManager.stranger == 3))
        {
            ButtonL.sprite = Final1;
            ButtonC.sprite = Final2;
            ButtonR.sprite = Final3;

            if (FinalSelection == false)
            {
                FinalSelection = true;
                ButtonBlocker.SetActive(false);
                Textbox.text = "Who killed you?";
            }
        }

        if (insideTrigger == true && (!TextObject.activeSelf))
        {

            ExeclaimationMark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TextObject.SetActive(true);
                PController.enabled = false;
            }
        }
        else if (insideTrigger == true && (TextObject.activeSelf))
        {

            ExeclaimationMark.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TextObject.SetActive(false);
                PController.enabled = true;
                ExeclaimationMark.SetActive(true);
            }
        }
        else
            ExeclaimationMark.SetActive(false);
    }


    public void ChooseRight()
    {
        StartCoroutine("Right");
    }

    public void ChooseWrong()
    {
        StartCoroutine("Wrong");
    }

    IEnumerator Wrong()
    {
        ButtonBlocker.SetActive(true);
        Textbox.text = "Try Again";
        yield return new WaitForSeconds(1.0f);
        Textbox.text = "Who do you think murdered you?";
        ButtonBlocker.SetActive(false);
    }

    IEnumerator Right()
    {
        ButtonBlocker.SetActive(true);
        Textbox.text = "You Choose Right";
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(scene);
        ButtonBlocker.SetActive(false);
    }
}
