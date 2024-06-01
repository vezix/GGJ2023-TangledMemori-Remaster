using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogues : ScriptableObject
{

    public string npcName;
    public Sprite Image;
    public List<string> npcConvo = new List<string>();

    public Dialogues(string npcName, Sprite Image, List<string> npcConvo)
    {
        this.npcName = npcName;
        this.Image = Image;
        this.npcConvo = npcConvo;
    }

}
