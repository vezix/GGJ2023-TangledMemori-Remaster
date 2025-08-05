using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    GameManager gameManager;
    private bool insideTrigger;
    public GameObject ExeclaimationMark;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager.stranger != 2)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player can pickup object");
            insideTrigger = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Byebye object");
            insideTrigger = false;
        }
    }

    void Update()
    {


        if (insideTrigger == true)
        {
            ExeclaimationMark.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameManager.wallet = 1;
                ExeclaimationMark.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
        else
            ExeclaimationMark.SetActive(false);

    }

}
