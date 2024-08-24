using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Interaction : MonoBehaviour
{

    public Dialog_Manager dialogmanager;
    public GameObject DialogueObject;

    //Create DialogueA dan DialogueB untuk variation dan juga Bool value untuk dah interact ke belum 

    public List<Dialogues> Dialogue = new List<Dialogues>();
    public List<Dialogues> interactedDialogue = new List<Dialogues>();
    public bool repeatDialoge = true;

    [SerializeField]
    private bool interacted = false;
    [SerializeField]   
    private bool MultipleDialog = false;

    private bool insideTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player can chat with npc");
            insideTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Byebye npc");
            insideTrigger = false;
        }
    }

    void Update()
    {
        if ( (insideTrigger == true) && (!DialogueObject.activeSelf))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogueStart();
            }
        }

    }

    void DialogueStart()
    {

        if (Dialogue == null)
        {
            Debug.Log("No Dialogue attached");
        }
        else if (Dialogue != null && interacted != true && MultipleDialog == false)
        {
                dialogmanager.Start_Dialog(Dialogue);
            if (repeatDialoge != true) 
            { 
                interacted = true; 
            }
        }
        else if (Dialogue != null && interacted == true && MultipleDialog == false)
        {
            dialogmanager.Start_Dialog(interactedDialogue);
        }

    }

}
