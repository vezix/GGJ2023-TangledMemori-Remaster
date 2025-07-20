using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovetoDifferentRoom : MonoBehaviour
{
    public string scene;
    private bool currentinteract = false;
    public GameObject ExeclaimationMark;

    private void Start()
    {
         ExeclaimationMark.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player In Portal");
            currentinteract = true;
            ExeclaimationMark.SetActive(true);  

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exit Portal");
            currentinteract = false;
            ExeclaimationMark.SetActive(false) ;
        }
    }

    private void Update()
    {
        if ((currentinteract == true) && (Input.GetKeyDown(KeyCode.Space)))
        {
                SceneManager.LoadScene(scene);
        }
    }
}
