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
    public player PController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Yes");
            insideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bye");
            insideTrigger = false;
        }
    }

    private void Update()
    {
        if(insideTrigger == true && (!TextObject.activeSelf))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TextObject.SetActive(true);
                PController.enabled = false;
            }
        }
        else if (insideTrigger == true && (TextObject.activeSelf))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TextObject.SetActive(false);
                PController.enabled = true;
            }
        }
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
        if (GameManager.sltstr == true)
        {

            Textbox.text = "Try Again";
            yield return new WaitForSeconds(1.0f);
            Textbox.text = "Who do you think murdered you?";
            //do this

            //go thru if 
        }
    }

    IEnumerator Right()
    {
        Textbox.text = "You Choose Right";
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(scene);
    }
}
