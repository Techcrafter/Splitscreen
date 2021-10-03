using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject PlayerIdleRight;
    public GameObject PlayerIdleLeft;
    public GameObject PlayerMoveRight;
    public GameObject PlayerMoveLeft;
    public GameObject PlayerJumpRight;
    public GameObject PlayerJumpLeft;
    
    int MoveLeft;
    
    public float MoveSpeed;
    public float JumpSpeed;
    public float JumpHeight;
    
    float JumpCount;
    
    float OldY;
    int Grounded;
    
    public GameObject LoadingText;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("PlayerStartPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerStartPosY", transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            MoveLeft = 0;
            PlayerIdleRight.SetActive(false);
            PlayerIdleLeft.SetActive(false);
            PlayerMoveRight.SetActive(true);
            PlayerMoveLeft.SetActive(false);
            PlayerJumpRight.SetActive(false);
            PlayerJumpLeft.SetActive(false);
            
            transform.position = new Vector2(transform.position.x + MoveSpeed * Time.deltaTime, transform.position.y);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            MoveLeft = 1;
            PlayerIdleRight.SetActive(false);
            PlayerIdleLeft.SetActive(false);
            PlayerMoveRight.SetActive(false);
            PlayerMoveLeft.SetActive(true);
            PlayerJumpRight.SetActive(false);
            PlayerJumpLeft.SetActive(false);
            
            transform.position = new Vector2(transform.position.x - MoveSpeed * Time.deltaTime, transform.position.y);
        }
        else if(MoveLeft == 0)
        {
            PlayerIdleRight.SetActive(true);
            PlayerIdleLeft.SetActive(false);
            PlayerMoveRight.SetActive(false);
            PlayerMoveLeft.SetActive(false);
            PlayerJumpRight.SetActive(false);
            PlayerJumpLeft.SetActive(false);
        }
        else if(MoveLeft == 1)
        {
            PlayerIdleRight.SetActive(false);
            PlayerIdleLeft.SetActive(true);
            PlayerMoveRight.SetActive(false);
            PlayerMoveLeft.SetActive(false);
            PlayerJumpRight.SetActive(false);
            PlayerJumpLeft.SetActive(false);
        }
        
        if(OldY > transform.position.y + 0.05f)
        {
            Grounded = 0;
            JumpCount = 0;
        }
        
        if(OldY < transform.position.y + 0.05f && OldY > transform.position.y - 0.05f)
        {
            Grounded = 1;
        }
        else if(OldY == transform.position.y)
        {
            Grounded = 1;
        }
        else
        {
            Grounded = 0;
        }
        
        OldY = transform.position.y;
        
        if(Input.GetKeyDown(KeyCode.Space) && Grounded == 1)
        {
            JumpCount = JumpHeight;
        }
        else if(!Input.GetKey(KeyCode.Space) && JumpCount > 0)
        {
            JumpCount = 0;
        }
        
        if(JumpCount > 0)
        {
            JumpCount -= 1 * Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y + JumpSpeed * Time.deltaTime);
            Grounded = 0;
        }
        
        if(Grounded == 0 && JumpCount > 0)
        {
            if(MoveLeft == 0)
            {
                PlayerIdleRight.SetActive(false);
                PlayerIdleLeft.SetActive(false);
                PlayerMoveRight.SetActive(false);
                PlayerMoveLeft.SetActive(false);
                PlayerJumpRight.SetActive(true);
                PlayerJumpLeft.SetActive(false);
            }
            else if(MoveLeft == 1)
            {
                PlayerIdleRight.SetActive(false);
                PlayerIdleLeft.SetActive(false);
                PlayerMoveRight.SetActive(false);
                PlayerMoveLeft.SetActive(false);
                PlayerJumpRight.SetActive(false);
                PlayerJumpLeft.SetActive(true);
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "KillPlayer")
        {
            die();
        }
        else if(collision.gameObject.tag == "LevelExit")
        {
            levelCompleted();
        }
    }
    
    void die()
    {
        GameObject.Find("DieAudio").GetComponent<AudioSource>().Play();
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("PlayerStartPosX"), PlayerPrefs.GetFloat("PlayerStartPosY"));
        }
        else
        {
            LoadingText.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
    
    void levelCompleted()
    {
        GameObject.Find("LevelCompletedAudio").GetComponent<AudioSource>().Play();
        LoadingText.SetActive(true);
        
        switch(SceneManager.GetActiveScene().name)
        {
            case "Level1":
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);
                break;
            case "Level2":
                SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                break;
            case "Level3":
                SceneManager.LoadScene("Level4", LoadSceneMode.Single);
                break;
            case "Level4":
                SceneManager.LoadScene("Level5", LoadSceneMode.Single);
                break;
            case "Level5":
                SceneManager.LoadScene("GameCompleted", LoadSceneMode.Single);
                break;
        }
    }
}
