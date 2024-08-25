using UnityEngine;

public class Actor : MonoBehaviour
{
    public string Name;
    public DialogueChoice Dialogue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Speakto();
        }
    }
    public void Speakto()
    {
        DialogueChoiceManager.Instance.StartDialogue(Name, Dialogue.RootNode);
    }
}
