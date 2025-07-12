using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class tree : MonoBehaviour
{
    bool wife;
    bool strange;
    bool chang;
    public GameObject TextObject;
    public SceneManage scene;
    public TextMeshProUGUI a,b,c;
    public Button a1, b1, c1;
    private bool insideTrigger = false;
    public player PController;


    // Start is called before the first frame update
    void Start()
    {
    }

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

    // Update is called once per frame
    void Update()
    {
        if(GameManager.wife == 1)
        { //inteact with wife

            wife = true;
            a.text = "wife";
            a1.onClick.AddListener(ChooseRight);
        }
        else
        {
            a.text = "???";
        }


        if (GameManager.strange == 1)
        { //interact with strange
            strange = true;
            b.text = "stranger";
            b1.onClick.AddListener(ChooseWrong);
        }
        else
        {
            b.text = "???";
        }

        if (GameManager.chang == 1)
        { //interact with change
            chang = true;
            c.text = "chang";
            c1.onClick.AddListener(ChooseWrong);
        }
        else
        {
            c.text = "???";
        }

        if (insideTrigger == true && (!TextObject.activeSelf))
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
        scene.SceneSwitch(6);
    }

    public void ChooseWrong()
    {
        scene.SceneSwitch(5);
    }
}
