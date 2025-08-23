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
                StartCoroutine("JS");
            }
            else
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

    }

    IEnumerator JS()
    {
        while (office == true)
        {
            ghost.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.01f));
            ghost.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.01f));
        }
    }

    IEnumerator JS1()
    {
        while (ChangJS == true)
        {
            Chang.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.01f));
            Chang.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.01f));
        }
    }

    void ghost1()
    {
        StartCoroutine("InvisibleGap");
    }
    IEnumerator InvisibleGap()
    {
        interaction.dialogmanager.AfterLastDialogue.RemoveListener(ghost1);
        StartCoroutine("JS1");
        yield return new WaitForSeconds(3f);
        ChangJS=false;
        interaction1.DialogueStart();
        Chang.SetActive(false);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<AudioManager>().stopAllBG();
        Note.SetActive(true);
        portal.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
