using System.Collections.Generic;
using System;

[System.Serializable]
public class DialogueNode 
{
    public string dialogueText;
    public List<DialogueResponse> responses;

    internal bool IsLastNode()
    {
        return responses.Count <= 0;
    }
}
