using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Interaction : MonoBehaviour
{

    public Dialog_Manager dialogmanager;
    public NPCInteraction Parent;

    //Create DialogueA dan DialogueB untuk variation dan juga Bool value untuk dah interact ke belum 

    public List<Dialogues> Dialogue = new List<Dialogues>();
    public List<Dialogues> interactedDialogue = new List<Dialogues>();
    public bool repeatDialoge = true;

    [SerializeField]
    private bool interacted = false;

    private void Awake()
    {
      Parent = GetComponentInParent<NPCInteraction>();
    }

    void OnEnable()
    {
        Parent.RefreshInteraction();
    }

    public void DialogueStart()
    {

        if (Dialogue == null)
        {
            Debug.Log("No Dialogue attached");
        }
        else if (Dialogue != null && interacted != true)
        {
                dialogmanager.Start_Dialog(Dialogue);
            //pastikan dialogue tak repeat 
            if (repeatDialoge != true) 
            { 
                interacted = true; 
            }
        }
        else if (Dialogue != null && interacted == true)
        {
            dialogmanager.Start_Dialog(interactedDialogue);
        }

    }

}
