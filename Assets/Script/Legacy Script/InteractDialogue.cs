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
    private bool firsttime = true;
    private bool insideTrigger = false;

    public GameObject UIDialogueObject;
    public TextMeshProUGUI UIDialogueName;
    public TextMeshProUGUI UIDialogueText;
    public Image UIDialougeImage;
    public player player;
    public int lastcount = 1;
    public int convocounter = 0;
    


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
        if (firsttime == true)
        {
            if ((convocounter < npcConvo.Count) && (insideTrigger == true))
            {
              if (Input.GetKeyDown(KeyCode.Space))
              {
                
                    if (!UIDialogueObject.activeSelf)
                    {
                        player.enabled = false;
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
                    firsttime = false;
                    UIDialogueObject.SetActive(false);
                    player.enabled = true;
                }
            }
        }
        else if(firsttime == false)
        {
            if ((lastcount < npcConvo.Count) && (insideTrigger == true))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    if (!UIDialogueObject.activeSelf)
                    {
                        player.enabled = false;
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
                        UIDialogueText.text = npcConvo[lastcount];
                        lastcount += 1;
                    }
                    else
                    {
                        UIDialogueText.text = npcConvo[lastcount];
                        lastcount += 1;
                    }
                }
            }
            else if ((lastcount <= npcConvo.Count) && (insideTrigger == true))
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    lastcount = 1;
                    firsttime = false;
                    UIDialogueObject.SetActive(false);
                    player.enabled = true;
                }
            }
        }
        }
        }
            
    


