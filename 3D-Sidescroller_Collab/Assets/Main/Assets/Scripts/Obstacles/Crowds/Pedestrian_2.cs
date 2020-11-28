using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian_2 : MonoBehaviour
{
    public InteractionWithPedestrian i_p;
    public MainPlayerController m_p_c;
    public Animator animator;
    private Rigidbody rb;

    private float xvalue;
    private float yvalue;
    private float zvalue;


    public bool playerhitpedestrian;
    public float xtransform = 0.05f;
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

    // Update is called once per frame
    void Update()
    {
        initiate();
        if (i_p.playerhitdestroy && !i_p.playerhitspawn)
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
        animator.SetBool("PlayerPassedYou", true);
        if (i_p.playerenterdtrigger)
        {
            
            rb.MovePosition(transform.position +(transform.forward *xtransform* Time.deltaTime));
            animator.SetBool("PlayerPassedYou", false);
        }
        
        if (i_p.pedestrianmoves)
        {                    
            animator.SetBool("PlayerPassedYou", false);
            animator.SetBool("ResetAnim", false);
            //xtransform = 0f;
            rb.isKinematic = true;

        }

        if (i_p.hitpedestrian)
        {
            xtransform = 0f;
           
            animator.SetBool("PlayerPassedYou", false);
        }
        if (i_p.timetofall && i_p.hitpedestrian)
        {
            xtransform = 0f;

        }
    }
    public void resetscript()
    {
        playerhitpedestrian = false;
        transform.position = new Vector3(xvalue, yvalue, zvalue);                         
        animator.SetBool("ResetAnim", true);
        rb.isKinematic = false;

    }
}
