using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public Rigidbody rb;
    public float movespeed;
    public Animator anim;
    public int isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isRunning", false);
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
            //transform.Translate(0, 0, 0.1f * Time.deltaTime);
            rb.AddForce(0, 0, 15);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded==1)
        {
            rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
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
