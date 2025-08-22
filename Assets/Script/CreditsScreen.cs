using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ProceedToMenu());
    }

    IEnumerator ProceedToMenu()
    {
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene("Splash");
    }
}
