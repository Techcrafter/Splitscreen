using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject LoadingText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadScene(string SceneName)
    {
        LoadingText.SetActive(false);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
