using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovetoDifferentRoom : MonoBehaviour
{
    public string scene;
    private bool currentinteract = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player In Portal");
            currentinteract = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exit Portal");
            currentinteract = false;
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
