using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Ans;
    public GameObject Phone;
    public SimpleCharacterController PController;
    public string scene;
    public GameObject ExeclaimationMark;
    public GameObject ButtonBlocker;
    private string Answer = "8562";
    bool insideTrigger = false;
    bool couroutineRunning = false;
    

    private void Start()
    {
        ExeclaimationMark.SetActive(false);
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
        if (insideTrigger == true && (!Phone.activeSelf))
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
        Ans.text += number.ToString();

        if (Ans.text.Length > 4)
        {
            Ans.text = Ans.text.Substring(0, 4);
        }
    }

    public void Execute()
    {
        if(Ans.text == Answer)
        {
            Ans.text = "Correct";
            StartCoroutine("OneS");
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

}
