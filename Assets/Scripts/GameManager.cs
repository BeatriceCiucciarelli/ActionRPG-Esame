using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DialogueManager DialogueManager;
    public DialogueHistoryTracker DialogueHistoryTracker;
    public LocationHistoryTracker LocationHistoryTracker;

    private void Awake()
    {
        if (Instance != null)   
        {
            Destroy(gameObject);
            return;
        }

        else
        {
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
