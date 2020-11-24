using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraspeed;
    public float moveinput = 0.7f;
    public float m_movespeed = 0.801f;



    public MainPlayerController cntller;

    void Start()
    {
        cntller= FindObjectOfType<MainPlayerController>();

        cameraspeed = moveinput * m_movespeed;
    }


    void Update()
    {
        m_movespeed = cntller.m_movespeed;
        cameraspeed = moveinput * m_movespeed;
        transform.position = transform.position + new Vector3(0f,0f,cameraspeed* Time.deltaTime);
    }
}
