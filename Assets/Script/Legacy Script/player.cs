using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    private BoxCollider2D boxcol;
    private Vector3 move;
    private Rigidbody2D rgb;

    public float speed = 10f;
    public SceneManage scene;
    public int scene1 = 1;
    public bool dr = false;
    public bool clct = false;
    public bool npc = false;
    public int npci = 0;
    public bool itc = false;
    public int itci = 0;

    // Start is called before the first frame update
    void Start()
    {
        boxcol = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        if (dr == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Change");
                scene.SceneSwitch(scene1);
            }
        }

        if (npc == true)
        {
            switch (npci)
            {
                case 1:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if(GameManager.wife == 0)
                        {
                            Debug.Log("Wife");
                            GameManager.wife += 1;
                        }
                        else
                        {
                            Debug.Log("Wife2");
                        }
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log("Stranger");
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log("Chang");
                    }
                    break;
            }
        }

        if (itc == true)
        {
            switch (itci)
            {
                case 1:
                    break;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log(GameManager.collect);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        move = new Vector3(x, 0, 0);

        if (move.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (move.x < 0)
        {
            transform.localScale = new Vector3(-1,1,0);
        }

        transform.Translate(move * speed * Time.deltaTime);

        GameManager.playerspd = x;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door1")
        {
            Debug.Log(dr);
            dr = true;
            Debug.Log(dr);
            scene1 = 2;
        }
        else if (collision.gameObject.tag == "Door2" && GameManager.wife == 1)
        {
            Debug.Log(dr);
            dr = true;
            scene1 = 3;
        }
        else if (collision.gameObject.tag == "Door3" && GameManager.wife == 1)
        {
            Debug.Log(dr);
            dr = true;
            scene1 = 4;
        }
        else if (collision.gameObject.tag == "Door4")
        {
            Debug.Log(dr);
            dr = true;
            Debug.Log(dr);
            scene1 = 1;
        }

        if (collision.gameObject.tag == "collectible1")
        {
            clct = true;
        }

        if (collision.gameObject.tag == "Door")
        {
            npc = true;
            npci = 0;
        }
        else if (collision.gameObject.tag == "Wife")
        {
            npc = true;
            npci = 1;
        }

        if (collision.gameObject.tag == "phone")
        {
            itc = true;
            itci = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dr = false;
        clct = false;
        npc = false;
        itc = false;
    }

}
