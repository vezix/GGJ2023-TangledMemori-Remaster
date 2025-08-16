using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Example variables you might want to persist
    [SerializeField]
    public int wife = 0;
    public int coworker = 0;
    public int stranger = 0;
    public int wallet = 0;
    public int Hobject = 0;
    public int TrainEnter = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Makes this GameObject persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicate GameManager instances
        }
    }


}
