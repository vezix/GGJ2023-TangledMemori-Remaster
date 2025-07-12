using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour

{
    public SceneManage scene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Credit");
    }

    // Update is called once per frame
    IEnumerator Credit()
    {
        yield return new WaitForSeconds(5f);
        //do this
        scene.SceneSwitch(0);
    }
}
