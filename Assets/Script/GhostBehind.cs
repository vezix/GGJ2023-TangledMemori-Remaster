using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehind : MonoBehaviour
{
    public GameObject DialogueObject;
    public Interaction interaction;
    public Interaction interaction1;

    public GameObject ghost;
    public GameObject Chang;
    public GameObject ChangSprite;
    public GameObject Note;
    public GameObject portal;

    public GameObject[] ChildObject;
    GameManager gameManager;

    public bool office = false;
    bool ChangJS = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (office == true)
        {
            if (gameManager.stranger == 2)
            {
                this.gameObject.SetActive(true);
            }else
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!DialogueObject.activeSelf)
            {
                if (office == true)
                {
                    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    ChangJS = true;
                    foreach (GameObject obj in ChildObject)
                    {
                        obj.GetComponent<BoxCollider2D>().enabled = false;
                    }
                    portal.SetActive(false);
                    interaction.DialogueStart();
                    gameManager.stranger = 3;
                    interaction.dialogmanager.AfterLastDialogue.AddListener(ghost1);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (office == true)
        {
            StartCoroutine("JS");
            if (ChangJS == true)
            {
                StartCoroutine("JS1");
            }
        }

    }

    IEnumerator JS()
    {
        ghost.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        ghost.SetActive(false);
    }

    IEnumerator JS1()
    {
        Chang.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Chang.SetActive(false);
    }

    void ghost1()
    {
        StartCoroutine("InvisibleGap");
    }
    IEnumerator InvisibleGap()
    {
        interaction.dialogmanager.AfterLastDialogue.RemoveListener(ghost1);
        yield return new WaitForSeconds(3f);
        ChangJS = false;
        Chang.SetActive(false);
        interaction1.DialogueStart();
        yield return new WaitForSeconds(1f);
        Note.SetActive(true);
        portal.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
