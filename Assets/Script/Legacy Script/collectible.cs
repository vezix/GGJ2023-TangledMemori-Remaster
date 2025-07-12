using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{

    public bool clct = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clct == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.collect += 1;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            clct = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        clct = false;
    }

}
