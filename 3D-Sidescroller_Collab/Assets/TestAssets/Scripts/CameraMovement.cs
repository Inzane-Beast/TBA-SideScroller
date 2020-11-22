using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraspeed;

    public PlayerContoller cntller;
    void Start()
    {
        cntller= FindObjectOfType<PlayerContoller>();
        cameraspeed = 0.3f;

    }


    void Update()
    {
        
        if (!cntller.playerisjumping && cntller.moveinput > 0)
        {                    
               cameraspeed = 0.8f;                                 
        }
        else
        {
            cameraspeed = 0.3f;
        }
      
        transform.position = transform.position + new Vector3(0f,0f,cameraspeed * Time.deltaTime);
    }
}
