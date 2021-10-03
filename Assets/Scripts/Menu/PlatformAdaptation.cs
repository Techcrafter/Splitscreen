using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAdaptation : MonoBehaviour
{
    public GameObject QuitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_WEBGL
            QuitButton.SetActive(false);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
