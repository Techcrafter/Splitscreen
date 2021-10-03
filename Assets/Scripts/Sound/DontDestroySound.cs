using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySound : MonoBehaviour
{
    public GameObject DieAudio;
    public GameObject LevelCompletedAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(DieAudio);
        DontDestroyOnLoad(LevelCompletedAudio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
