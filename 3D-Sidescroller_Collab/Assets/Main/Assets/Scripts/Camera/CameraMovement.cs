using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraspeed;
    public float moveinput = 0.7f;
    public float m_movespeed = 0.801f;

    public PlayerContoller cntller;
    void Start()
    {
        cntller= FindObjectOfType<PlayerContoller>();
        cameraspeed = moveinput * m_movespeed;
      
    }


    void Update()
    {
       transform.position = transform.position + new Vector3(0f,0f,cameraspeed * Time.deltaTime);
    }
}
