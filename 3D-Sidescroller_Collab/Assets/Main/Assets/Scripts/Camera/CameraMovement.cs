using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraspeed;
    public float moveinput = 0.7f;
    public float m_movespeed = 0.801f;



    public MainPlayerController cntller;
    public PlayerScore p_score;

    void Start()
    {
        cntller= FindObjectOfType<MainPlayerController>();
        p_score = FindObjectOfType<PlayerScore>();

        cameraspeed = moveinput * m_movespeed;
    }


    void Update()
    {
        if (!cntller.G_GameOver)
        {
          
            if (p_score.increaselevel)
            {
                m_movespeed = m_movespeed + p_score.p_speedincrease;
            }
            if (cntller.playerhitsoftobstacles)
            {
                moveinput = 0.7f;
            }
            if (!cntller.playerhitsoftobstacles && cntller.boostenergy)
            {
                moveinput = 0.6f;
            }
            cameraspeed = moveinput * m_movespeed;
            transform.position = transform.position + new Vector3(0f, 0f, cameraspeed * Time.deltaTime);
        }   
        else
        {
           Time.timeScale = 0;
        }
    }
}
