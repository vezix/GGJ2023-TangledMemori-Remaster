using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIF_ByFrame : MonoBehaviour
{
    [SerializeField] bool loop;
    [SerializeField] float interval;
    [SerializeField] SpriteRenderer placeHolder;
    [SerializeField] Sprite[] frames;
    [SerializeField] Sprite[] Movingframes;

    float timer;
    int i;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {

            placeHolder.sprite = frames[i];
            timer = 0;
            i++;
            if (i >= frames.Length && loop)
            {
                i = 0;
            }
        }
    }
}