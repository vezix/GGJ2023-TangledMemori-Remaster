using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Manager : MonoBehaviour
{
    public GameObject DialogueObject;
    public TextMeshProUGUI DialogueName;
    public TextMeshProUGUI DialogueText;
    public SimpleCharacterController PController;
    public Image DialogueImage;
    public static Dialog_Manager Instance { get; private set; }

    public float textSpeed;

    [SerializeField]
    private List<Dialogues> dialog_copy;
    [SerializeField]
    private List<string> conversation;
    [SerializeField]
    private int ListIndex = 0;

    //tak tahu kenapa currListIndex akan start ngan 1 instead of 0 , jadi kena set dialog 0 sbagai buffer , you know what, fuck this just pakai org lain punya 
    [SerializeField]
    private int currListIndex = 0;
    [SerializeField]
    private int dialogueIndex = 0;
    [SerializeField]
    private int currDialogueIndex = 0;
    //halang dari spam next sentence sebelum current siap

    //check if convo dah mula belum
    [SerializeField]
    private bool begun = false;
    [SerializeField]
    private bool convodone = true;

    private float lastSpacePressTime = 0f;
    private float spacePressCooldown = 0.5f; // Adjust this value as needed/

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of DialogueManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Initially hide the dialogue UI
        HideDialogue();
    }

    public void HideDialogue()
    {
        DialogueObject.SetActive(false);
    }

    public void Start_Dialog(List<Dialogues> _dialog)
    {
        dialog_copy = _dialog;
        ListIndex = (_dialog.Count - 1);

        if (_dialog[currListIndex].Image == null)
        {
            DialogueImage.enabled = false;
        }
        else
        {
            DialogueImage.enabled = true;
            DialogueImage.sprite = _dialog[currListIndex].Image; ;
        }

        DialogueName.text = _dialog[currListIndex].npcName;
        conversation = new List<string>(_dialog[currListIndex].npcConvo);
        currDialogueIndex = 0;
        dialogueIndex = _dialog[currListIndex].npcConvo.Count;
        PController.SetVelocity(0f);
        PController.enabled = false;

        if (currDialogueIndex < dialogueIndex)
        {
            begun = true;
            Displaytext();
        }
        else
        {
            Debug.Log("No text");
        }
    }

    void Displaytext()
    {
        DialogueObject.SetActive(true);
        DialogueText.text = string.Empty;
        //Add script where courutine plays animation typing one BY one 
        //DialogueText.text = conversation[currDialogueIndex];
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in conversation[currDialogueIndex].ToCharArray())
        {
            convodone = false;
            DialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        convodone = true;
    }

    //Solve issue where spamming breaks Dialogue system as Update is faster than its other function. 

    private void SetDialogueText()
    {
        DialogueText.text = conversation[currDialogueIndex];
    }

    //curr problem Update run faster than time as courutine. jadi x leh nak skip current dialogue, solution create something slower than update. 
    private void Update()
    {
        if ((DialogueObject.activeSelf) && (begun == true))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time - lastSpacePressTime > spacePressCooldown)
                {
                    lastSpacePressTime = Time.time;

                    if (convodone == true)
                    {
                        if (DialogueText.text == conversation[currDialogueIndex])
                        {
                            currDialogueIndex++;
                            NextSentence();
                        }
                    }
                }
            }
        }
    }


    public void NextSentence()
    {
        if (currDialogueIndex < dialogueIndex)
        {
            Displaytext();
        }
        else
        {
            if (currListIndex < ListIndex)
            {
                currListIndex++;
                currDialogueIndex = 0;
                Start_Dialog(dialog_copy);

            }
            else
            {
                EndDialogue();
            }
        }
    }

    private void EndDialogue()
    {
        begun = false;
        ListIndex = 0;
        dialogueIndex = 0;
        currDialogueIndex = 0;
        currListIndex = 0;
        DialogueObject.SetActive(false);
        DialogueText.text = "";
        dialog_copy = null;
        conversation = null;
        PController.enabled = true;
    }

}

//OLD CODE

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class Dialog_Manager : MonoBehaviour
//{
//    public GameObject DialogueObject;
//    public TextMeshProUGUI DialogueName;
//    public TextMeshProUGUI DialogueText;
//    public SimpleCharacterController PController;
//    public Image DialogueImage;

//    [SerializeField]
//    private List<Dialogues> dialog_copy;
//    [SerializeField]
//    private List<string> conversation;
//    [SerializeField]
//    private int ListIndex = 0;
//    //ada error bila first enter infinite loop bila load scene, rasa kena clear out/reinitialize shit.
//    //tak tahu kenapa currListIndex akan start ngan 1 instead of 0 , jadi kena set dialog 0 sbagai buffer
//    [SerializeField]
//    private int currListIndex = 0;
//    [SerializeField]
//    private int dialogueIndex = 0;
//    [SerializeField]
//    private int currDialogueIndex = 0;
//    //halang dari spam next sentence sebelum current siap
//    private bool FirstDialog = true;
//    //check if convo dah mula belum
//    private bool begun = false;

//    public void Start_Dialog(List<Dialogues> _dialog)
//    {
//        dialog_copy = _dialog;
//        ListIndex = (_dialog.Count - 1);

//        if (_dialog[currListIndex].Image == null)
//        {
//            DialogueImage.enabled = false;
//        }
//        else
//        {
//            DialogueImage.enabled = true;
//            DialogueImage.sprite = _dialog[currListIndex].Image; ;
//        }

//        DialogueName.text = _dialog[currListIndex].npcName;
//        conversation = new List<string>(_dialog[currListIndex].npcConvo);
//        currDialogueIndex = 0;
//        dialogueIndex = _dialog[currListIndex].npcConvo.Count;
//        PController.enabled = false;
//        //Add script where it takes and locks player current Coordinate. 

//        if (currDialogueIndex < dialogueIndex)
//        {
//            begun = true;
//            FirstDialog = false;
//            Displaytext();
//        }
//        else
//        {
//            Debug.Log("No text");
//        }
//    }

//    void Displaytext()
//    {
//        DialogueObject.SetActive(true);
//        DialogueText.text = "";
//        //Add script where courutine plays animation typing one BY one 
//        DialogueText.text = conversation[currDialogueIndex];
//        currDialogueIndex++;
//        FirstDialog = true;
//    }

//    private void Update()
//    {
//        if ((DialogueObject.activeSelf) && (begun == true))
//        {
//            if (FirstDialog == true)
//            {
//                if (Input.GetKeyDown(KeyCode.Space))
//                {
//                    FirstDialog = false;
//                    NextSentence();
//                }
//            }
//        }
//    }

//    public void NextSentence()
//    {
//        FirstDialog = false;

//        if (currDialogueIndex < dialogueIndex)
//        {
//            Displaytext();
//        }
//        else
//        {
//            if (currListIndex < ListIndex)
//            {
//                currListIndex++;
//                currDialogueIndex = 0;
//                Start_Dialog(dialog_copy);
//                FirstDialog = true;

//            }
//            else
//            {
//                DialogueObject.SetActive(false);
//                DialogueText.text = "";
//                PController.enabled = true;
//                FirstDialog = true;
//                dialog_copy = null;
//                conversation = null;
//                ListIndex = 0;
//                dialogueIndex = 0;
//                currDialogueIndex = 0;
//                currListIndex = 0;
//                begun = false;
//            }
//        }
//    }

//}
