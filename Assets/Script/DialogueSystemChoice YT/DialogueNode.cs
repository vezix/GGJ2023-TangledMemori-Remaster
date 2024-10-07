using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class DialogueNode 
{
    public string dialogueText;
    public Sprite Image;
    public List<DialogueResponse> responses;

    internal bool IsLastNode()
    {
        return responses.Count <= 0;
    }
}
