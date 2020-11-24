using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public Animator m_anim;
    public Rigidbody rb;
    public CharacterController c_cntrl;

    public float m_movespeed = 0.801f;
    public float m_forwardSpeed;
    public float moveinput = 0.7f;
    public float m_jumpspeed = 3.0f;
    public int isGrounded;

    public bool plyerismoving = false;
    public bool ActivateManualRunning = true;
    public bool playercanmove = true;
    public bool ControlledByCh_cntrller = false;
    public bool ControlledByRigidBody = true;

    private Vector3 Movement = Vector3.zero;

    public string movekey = "Horizontal";
    private Hydrant hyd_obs;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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
    private void FixedUpdate()
    {

    }
    void PlayerMovement()
    {
        
        if (ControlledByRigidBody)
        {
            rb.velocity = new Vector3(0f, 0f, m_movespeed);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == 1)
            {
                m_anim.SetBool("isjumping", true);
                m_anim.SetBool("isrunning", false);
                rb.AddForce(Vector3.up * m_jumpspeed, ForceMode.Impulse);
            }
            else
            {
                m_anim.SetBool("isjumping", false);
                m_anim.SetBool("isrunning", true);
            }
        }

        if (ControlledByCh_cntrller)
        {
            if (!ActivateManualRunning)
            {
                moveinput = 0.7f;
                m_movespeed = 0.801f;
            }
            Movement.z = moveinput * m_movespeed;
           
            if (Input.GetButton("Jump") && c_cntrl.isGrounded)
            {
                Movement.y = m_jumpspeed;
            }
            Movement.y = Movement.y + Physics.gravity.y;
            c_cntrl.Move(Movement * Time.deltaTime);

            if (Input.GetButton("Jump") && c_cntrl.isGrounded)
            {
                m_anim.SetBool("isjumping", true);
                m_anim.SetBool("isrunning", false);
            }
            else
            {
                m_anim.SetBool("isjumping", false);
                m_anim.SetBool("isrunning", true);
            }
        }      
       
    }
    void playerfelldown()
    {
        m_anim.SetBool("isrunning", false);
        m_anim.SetBool("isjumping", false);
        m_anim.SetTrigger("HardCollided");
        playercanmove = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = 0;
        }
    }
}
