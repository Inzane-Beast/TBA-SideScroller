using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    public CharacterController c_cntrl;
    public Animator m_anim;
    private Hydrant hyd_obs;
    public PlatformManager m_plftformmnger;
    public int m_platfrmlocat;

    public float m_movespeed = 0.801f;
    public float moveinput = 0.7f;
    public float Gravity = -9.81f;
    public float p_jumpheight = 3f;
    public int speedlimit = 10;
    private int value = 0;


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
        m_plftformmnger = FindObjectOfType<PlatformManager>();
    }


    void Update()
    {
        playerDifficultySpeed();

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
    void playerDifficultySpeed()
    {
        for (int i = value; i == m_plftformmnger._zedoffset; i = i + 5)
        {
            if (i == speedlimit)
            {
                speedlimit = m_plftformmnger._zedoffset;
                speedlimit = speedlimit + 10;
                value = speedlimit;
            }

        }

        if (m_plftformmnger._zedoffset == speedlimit)
        {
            m_movespeed = m_movespeed + 0.005f;
        }
    }
}

