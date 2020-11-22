using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public CharacterController c_cntrl;
    public Animator m_anim;

    public float m_movespeed = 1.5f;
    public float m_forwardSpeed;
    public float m_desierd_speed;

    public float moveinput = 0f;
    public string movekey = "Horizontal";

    public bool plyerismoving = false;
    public bool playerisjumping = false;
    public bool ActivateManualRunning = true;

    void Start()
    {
        m_anim = gameObject.GetComponent<Animator>();
        c_cntrl = GetComponent<CharacterController>();
       
    }

    
    void Update()
    {
        HorizontalMovement();
        
    }

    void HorizontalMovement()
    {
        moveinput = Input.GetAxis(movekey);
        if (moveinput < 0)
        {
            moveinput = 0;
        }

        if (!ActivateManualRunning)
        {
            moveinput = 1;
            m_movespeed = 0.801f;
        }

        Vector3 Movement = transform.TransformDirection(Vector3.forward);
        m_forwardSpeed = m_movespeed * moveinput;
        c_cntrl.SimpleMove(Movement * m_forwardSpeed);

        if (moveinput < 0.1)
        {
            m_anim.SetBool("isrunning", true);
        }
        if (moveinput == 0)
        {
            m_anim.SetBool("isrunning", false);
        }
        if(!playerisjumping && moveinput >0 && moveinput < 0)
        {
            plyerismoving = true;
        }
        else
        {
            plyerismoving = false;
        }
}

}
