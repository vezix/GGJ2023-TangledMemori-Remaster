using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subway : MonoBehaviour
{
    public GameObject wallet;
    public GameObject back2;

    // Start is called before the first frame update
    void Start()
    {
        wallet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.chang2 != 0)
        {
            wallet.SetActive(true);
        }
        if(GameManager.js != 0)
        {
            StartCoroutine("JS");
            
        }
    }

    IEnumerator JS()
    {
        back2.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        back2.SetActive(false);
        GameManager.js = 0;
    }
}
