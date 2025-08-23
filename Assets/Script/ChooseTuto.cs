using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseTuto : MonoBehaviour
{

    private bool insideTrigger = false;
    public string scene;
    public GameObject TextObject;
    public TextMeshProUGUI Textbox;
    public SimpleCharacterController PController;
    public GameObject ExeclaimationMark;
    public GameObject ButtonBlocker;

    private void Start()
    {
        ExeclaimationMark.SetActive(false);
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
        if (insideTrigger == true && (!TextObject.activeSelf))
        {
            ExeclaimationMark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //FindObjectOfType<AudioManager>().PlaySFX("Grass");
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


    public void Choose()
    {
        StartCoroutine("Right");
    }

    IEnumerator Right()
    {
        ButtonBlocker.SetActive(true);
        Textbox.text = ".....";
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
    }
}
