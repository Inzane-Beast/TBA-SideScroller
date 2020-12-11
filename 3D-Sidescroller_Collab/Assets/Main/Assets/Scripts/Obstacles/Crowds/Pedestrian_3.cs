using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian_3 : MonoBehaviour
{
    public InteractionWithPedestrian i_p;
    public MainPlayerController m_p_c;
    public Animator animator;
    private Rigidbody rb;

    private float xvalue;
    private float yvalue;
    private float zvalue;

    public bool playerhitpedestrian;

    public float xtransform = 0.2f;
    void Start()
    {
        i_p = FindObjectOfType<InteractionWithPedestrian>();
        m_p_c = FindObjectOfType<MainPlayerController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        xvalue = this.gameObject.transform.position.x;
        yvalue = this.gameObject.transform.position.y;
        zvalue = this.gameObject.transform.position.z;
    }

    void Update()
    {
        if (i_p.playerhitdestroy)
        {
            resetscript();
        }
        if (i_p.playerhitspawn)
        {
            initiate();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Player"))
        {
            playerhitpedestrian = true;

        }
    }
    public void initiate()
    {
        if (i_p.playerenterdtrigger)
        {
            this.gameObject.transform.Translate(0f, 0f, xtransform * Time.deltaTime);

        }

        if (i_p.pedestrianmoves && !i_p.timetofall)
        {
            xtransform = 0f;
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            rb.AddForce(0f, 0f, 0.30f * Time.deltaTime, ForceMode.Impulse);
            animator.SetBool("timetododge", true);
            animator.SetBool("playerpassedyou", false);

        }
        if (i_p.leftsection)
        {
            xtransform = 0f;
        }

        if (i_p.hitpedestrian)
        {
            xtransform = 0f;
            animator.SetTrigger("PlayerHityou");
            animator.SetBool("playerpassedyou", false);
            animator.SetBool("timetododge", false);
        }
        if (i_p.timetofall && i_p.hitpedestrian)
        {           
            xtransform = 0f;
            animator.SetTrigger("PlayerHityou");
            animator.SetBool("playerpassedyou", false);
            animator.SetBool("timetododge", false);
        }
    }
    public void resetscript()
    {
        playerhitpedestrian = false;
        transform.position = new Vector3(xvalue, 0, zvalue);
        this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        animator.SetBool("playerpassedyou", true);
        animator.SetBool("timetododge", false);
        animator.ResetTrigger("PlayerHityou");

    }
}
