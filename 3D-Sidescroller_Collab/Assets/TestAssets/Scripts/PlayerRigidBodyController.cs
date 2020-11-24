using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidBodyController : MonoBehaviour
{
    public float p_movespeed;
    public float p_jumpspeed;
    public float moveinput;

    public string movekey = "Horizontal";

    public Rigidbody rb;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        moveinput = Input.GetAxis(movekey);
        Vector3 movement = new Vector3(0f, 0f, moveinput);        
        rb.AddForce(movement * p_movespeed);
    }
}
