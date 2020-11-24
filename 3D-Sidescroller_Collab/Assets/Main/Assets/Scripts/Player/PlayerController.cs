using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController c_cntrl;
    public Animator m_anim;
    private Hydrant hyd_obs;

    public float m_movespeed = 0.801f;
    public float moveinput = 0.7f;
    public float Gravity = -9.81f;
    public float p_jumpheight = 3f;


    public bool isGrounded;

    public Transform groundcheck;
    public float GroundDistance = 0.2f;
    public LayerMask GroundMask;

    private Vector3 Velocity;

    void Start()
    {
        m_anim = gameObject.GetComponent<Animator>();
        c_cntrl = GetComponent<CharacterController>();
        hyd_obs = FindObjectOfType<Hydrant>();
    }

    // Update is called once per frame
    void Update()
    {
        playermovement();
        if (hyd_obs.PlayerHitHydrant)
        {
            playerfelldown();
        }
        else
        {
            playermovement();
        }
                     
    }
    void playerfelldown()
    {
        m_anim.SetBool("isrunning", false);
        m_anim.SetBool("isjumping", false);
        m_anim.SetTrigger("HardCollided");
    }
    void playermovement()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, GroundDistance, GroundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        moveinput = 0.7f;
        Vector3 Movement = transform.forward * moveinput;
        c_cntrl.Move(Movement * m_movespeed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Velocity.y = Mathf.Sqrt(p_jumpheight * -2 * Gravity);
            m_anim.SetBool("isjumping", true);
            m_anim.SetBool("isrunning", false);
        }
        else
        {
            m_anim.SetBool("isjumping", false);
            m_anim.SetBool("isrunning", true);
        }
        Velocity.y += Gravity * Time.deltaTime;
        c_cntrl.Move(Velocity * Time.deltaTime);
    }
}
