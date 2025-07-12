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
    public player PController;
    public string scene;

    private string Answer = "8562";
    bool insideTrigger = false;
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
        if (insideTrigger == true && (!Phone.activeSelf))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Phone.SetActive(true);
                PController.enabled = false;
            }
        }
        else if (insideTrigger == true && (Phone.activeSelf))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Phone.SetActive(false);
                PController.enabled = true;
            }
        }
    }


    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Execute()
    {
        if(Ans.text == Answer)
        {
            Ans.text = "Correct";
            StartCoroutine("OneS");
            SceneManager.LoadScene(scene);
        }
        else
        {
            Ans.text = "wrong pass";
            StartCoroutine("OneS");
            
        }
    }

    IEnumerator OneS()
    {
        yield return new WaitForSeconds(1.0f);
        Ans.text = "";
    }

}
