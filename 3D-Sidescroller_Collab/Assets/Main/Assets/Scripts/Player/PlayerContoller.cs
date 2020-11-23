using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public CharacterController c_cntrl;
    public Animator m_anim;

    public float m_movespeed = 0.801f;
    public float m_forwardSpeed;
    public float VerticalVelocity;
    public float m_jumpspeed;
    public float gravity;

    public float moveinput = 0.7f;
    public string movekey = "Horizontal";
    public string jumpkey = "Jump";

    public bool plyerismoving = false;
    public bool playerisjumping;
    public bool ActivateManualRunning = true;
    public bool playercanmove = true;

    
    private Vector3 Movement = Vector3.zero;

    private Hydrant hyd_obs;

    void Start()
    {
        m_anim = gameObject.GetComponent<Animator>();
        c_cntrl = GetComponent<CharacterController>();
        hyd_obs = FindObjectOfType<Hydrant>();
    }


    void Update()
    {
        if (hyd_obs.PlayerHitHydrant)
        {
            playerfelldown();
        }

        if (playercanmove)
        {
            PlayerMovement();
        }
    
    }

    void PlayerMovement()
    {

        if (c_cntrl.isGrounded)
        {

            VerticalVelocity = -gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                VerticalVelocity = m_jumpspeed;

            }
        }
        else
        {

            VerticalVelocity -= gravity * Time.deltaTime;

        }

        if (!ActivateManualRunning)
        {
            moveinput = 0.7f;
            m_movespeed = 0.801f;
        }

        Movement.y = VerticalVelocity;
        Movement.z = moveinput * m_movespeed;
        c_cntrl.Move(Movement * Time.deltaTime);

        if (!c_cntrl.isGrounded && Input.GetButton(jumpkey))
        {
            m_anim.SetBool("isrunning", false);
            playerisjumping = true;
            m_anim.SetBool("isjumping", true);

        }
        else
        {
            playerisjumping = false;
            m_anim.SetBool("isjumping", false);
            m_anim.SetBool("isrunning", true);
        }

    }
    void playerfelldown()
    {
        m_anim.SetBool("isrunning", false);
        m_anim.SetBool("isjumping", false);
        m_anim.SetTrigger("HardCollided");
        playercanmove = false;
    }


}