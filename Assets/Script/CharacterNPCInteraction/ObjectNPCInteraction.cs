using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNPCInteraction : MonoBehaviour
{
    public GameObject DialogueObject;
    public Interaction interaction;
    public GameObject ExeclaimationMark;

    public void Start()
    {
        //NOT FINAL, create a script where when you 
        interaction = GetComponentInChildren<Interaction>();
        ExeclaimationMark.SetActive(false);
    }

    public void RefreshInteraction()
    {
        interaction = GetComponentInChildren<Interaction>();
    }

    public void StartDialogue()
    {
        interaction.DialogueStart();
    }


}
