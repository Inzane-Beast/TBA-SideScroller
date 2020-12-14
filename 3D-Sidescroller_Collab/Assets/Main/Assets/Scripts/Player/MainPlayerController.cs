using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    public CharacterController c_cntrl;
    public PlayerScore p_score;
    public Animator m_anim;
    public PlatformManager m_plftformmnger;
    public int m_platfrmlocat;

    public float m_movespeed = 0.801f;
    public float moveinput = 0.7f;
    public float Gravity = -9.81f;
    public float p_jumpheight = 3f;
    public int speedlimit = 10;
   // private int value = 0;
    public bool playercanmove = true;
    public bool playerhitsoftobstacles = false;
    public bool boostenergy = false;
    public bool G_GameOver = false;
    public bool playerdead = false;

    public GameObject gameoverUi;
    public GameObject HUD;



    public bool isGrounded;

    public Transform groundcheck;
    public float GroundDistance = 0.2f;
    public LayerMask GroundMask;

    private Vector3 Velocity;

    void Start()
    {
        m_anim = gameObject.GetComponent<Animator>();
        c_cntrl = GetComponent<CharacterController>();
        m_plftformmnger = FindObjectOfType<PlatformManager>();
        p_score = GetComponent<PlayerScore>();
    }


    void Update()
    {
        if (G_GameOver)
        {
            Time.timeScale = 0;
            gameoverUi.SetActive(true);
            HUD.SetActive(false);
          
        }
        if (playerhitsoftobstacles)
        {
            StartCoroutine(softobstaclehit());
            boostenergy = true;
            if (boostenergy)
            {
                moveinput = 0.7f;
            }
        }

       
        if (!playercanmove && playerdead)
        {
            playerfelldown();

        }
        else
        {
            playermovement();
            playerDifficultySpeed();
        }

    }
    public void playerfelldown()
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

        
        Vector3 Movement = transform.forward * moveinput;
        c_cntrl.Move(Movement * m_movespeed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Velocity.y = Mathf.Sqrt(p_jumpheight * -2 * Gravity);
            m_anim.SetBool("isjumping", true);
            m_anim.SetBool("isrunning", false);        
           FindObjectOfType<AudioManager>().Play("J1");
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
        if (p_score.increaselevel)
        {
            m_movespeed = m_movespeed + p_score.p_speedincrease;
        }
        else
        {
            m_movespeed = m_movespeed + 0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            playercanmove = false;
        }
        else
        {
            playercanmove = true;
            playerdead = true;
        }

        if (other.gameObject.CompareTag("SoftObstacles"))
        {
            m_movespeed = m_movespeed - 0.03f;
            playerhitsoftobstacles = true;

        }
        else
        {
            playerhitsoftobstacles = false;
        }
     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            G_GameOver = true;
        }
        
    }
    private IEnumerator softobstaclehit()
    {
        yield return new WaitForSeconds(0.3f);
       
        playerhitsoftobstacles = false;

    }
    
   

    
}

