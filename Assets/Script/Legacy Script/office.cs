using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class office : MonoBehaviour
{
    public GameObject changdesk;
    public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        changdesk.SetActive(false);
        ghost.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.strange == 2)
        {
            StartCoroutine("JS");
        }
        if (GameManager.strange == 3)
        {
            changdesk.SetActive(true);
        }
    }

    IEnumerator JS()
    {
        ghost.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        ghost.SetActive(false);
        GameManager.js = 0;
    }
}
