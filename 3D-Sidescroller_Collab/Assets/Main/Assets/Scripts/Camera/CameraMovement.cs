using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CameraMovement : MonoBehaviour
{
    public float cameraspeed;
    public float moveinput = 0.7f;
    public float m_movespeed = 0.801f;

    public GameObject bgaudio;
    public AudioSource acon;



    public MainPlayerController cntller;
    public PlayerScore p_score;
    public InteractionWithPedestrian i_ped;

    void Start()
    {
        cntller= FindObjectOfType<MainPlayerController>();
        p_score = FindObjectOfType<PlayerScore>();
        i_ped = FindObjectOfType<InteractionWithPedestrian>();
        acon = bgaudio.GetComponent<AudioSource>();

        cameraspeed = moveinput * m_movespeed;
        
    }


    void Update()
    {
        if (i_ped.endthecamera)
        {
            Time.timeScale = 0;
        }
        


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
                // moveinput = 0.6f;
                moveinput = 0.7f;
            }
            cameraspeed = moveinput * m_movespeed;
            transform.position = transform.position + new Vector3(0f, 0f, cameraspeed * Time.deltaTime);
            
        }   
        else
        {
           Time.timeScale = 0;
            acon.enabled = false;
            
        }
    }
}
