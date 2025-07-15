using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InteractDialogue : MonoBehaviour
{
    public string npcName;
    public Sprite Image;
    public List<string> npcConvo = new List<string>();
    [SerializeField]
    private int convocounter = 0;
    [SerializeField]
    private bool insideTrigger = false;

    public GameObject UIDialogueObject;
    public TextMeshProUGUI UIDialogueName;
    public TextMeshProUGUI UIDialogueText;
    public Image UIDialougeImage;
    public SimpleCharacterController PController;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player can interact");
            insideTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player can No longer interact");
            insideTrigger = false;
        }
    }
    private void Update()
    {
        if ((convocounter < npcConvo.Count) && (insideTrigger == true))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!UIDialogueObject.activeSelf)
                {
                    PController.enabled = false;
                    UIDialogueObject.SetActive(true);
                    if (Image == null)
                    {
                        UIDialougeImage.enabled = false;
                    }
                    else
                    {
                        UIDialougeImage.enabled = true;
                        UIDialougeImage.sprite = Image;
                    }
                    UIDialogueName.text = npcName;
                    UIDialogueText.text = npcConvo[convocounter];
                    convocounter += 1;
                }
                else
                {
                    UIDialogueText.text = npcConvo[convocounter];
                    convocounter += 1;
                }

            }
        }
        else if ((convocounter <= npcConvo.Count) && (insideTrigger == true))
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                convocounter = 0;
                UIDialogueObject.SetActive(false);
                PController.enabled = true;
            }
        }
    }

}