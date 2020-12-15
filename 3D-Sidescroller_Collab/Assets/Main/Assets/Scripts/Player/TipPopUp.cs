using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipPopUp : MonoBehaviour
{
    public GameObject jumpobject;
    public GameObject witsleobject;

    public void Start()
    {
        jumpobject = GetComponent<GameObject>();
        witsleobject = GetComponent<GameObject>();
    }
    void Update()
    {
        
    }
   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("jumpMsge"))
        {
            jumpobject.SetActive(true);
        }
        if (other.gameObject.CompareTag("witlemsge"))
        {
            witsleobject.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("jumpMsge"))
        {
            jumpobject.SetActive(false);
        }
        if (other.gameObject.CompareTag("witlemsge"))
        {
            witsleobject.SetActive(false);
        }
    }
}
