using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian_1 : MonoBehaviour
{
    public InteractionWithPedestrian i_p;
    public MainPlayerController m_p_c;
    public Animator animator;
    private Rigidbody rb;

    public bool playerhitpedestrian;

    private float  xvalue;
    private float yvalue;
    private float zvalue;

    public float xtransform = 0.2f;
    // Start is called before the first frame update
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
        if (i_p.pedestrianmoves)
        {
           
            rb.AddForce(0f, 0f, -xtransform * Time.deltaTime, ForceMode.Impulse);
            animator.SetBool("timetododge", true);
            animator.SetBool("playerpassedyou", false);

        }
      
        if (i_p.leftsection)
        {
            xtransform = 0f;
        }

        if (i_p.hitpedestrian)
        {
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
        transform.position = new Vector3(xvalue, yvalue, zvalue);
        animator.SetBool("playerpassedyou",true);
        animator.SetBool("timetododge", false);
        animator.ResetTrigger("PlayerHityou");
       // animator.ResetTrigger("PlayernearYou");
       

    }
}
