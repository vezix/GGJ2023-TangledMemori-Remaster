using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ProceedToMenu());
    }

    IEnumerator ProceedToMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TitleScreen");
    }
}
