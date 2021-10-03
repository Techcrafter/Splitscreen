using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    float VX;
    float VY;
    float VR;
    
    public float XBorder;
    public float YBorder;
    
    // Start is called before the first frame update
    void Start()
    {
        VX = Random.Range(0.005f, 0.05f);
        VY = Random.Range(-0.005f, -0.05f);
        VR = Random.Range(0.25f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, VR));
        transform.position = new Vector2(transform.position.x + VX, transform.position.y + VY);
        
        if(transform.position.x < -XBorder)
        {
            transform.position = new Vector2(-XBorder, transform.position.y);
            VX *= -1;
        }
        else if(transform.position.x > XBorder)
        {
            transform.position = new Vector2(XBorder, transform.position.y);
            VX *= -1;
        }
        
        if(transform.position.y < -YBorder)
        {
            transform.position = new Vector2(transform.position.x, -YBorder);
            VY *= -1;
        }
        else if(transform.position.y > YBorder)
        {
            transform.position = new Vector2(transform.position.x, YBorder);
            VY *= -1;
        }
    }
}
