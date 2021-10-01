using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        
        if(OldY < transform.position.y + 0.1f || OldY > transform.position.y - 0.1f)
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
        
        if(JumpCount > 0)
        {
            JumpCount -= 1 * Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y + JumpSpeed * Time.deltaTime);
            Grounded = 0;
        }
        
        if(Grounded == 0)
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
}
