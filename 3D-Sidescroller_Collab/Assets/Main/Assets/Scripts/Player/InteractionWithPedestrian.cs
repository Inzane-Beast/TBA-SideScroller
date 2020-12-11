using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithPedestrian : MonoBehaviour
{
    public bool playercanwitsle = false;
    public bool playerwitsled = false;
    public bool leftsection = false;

    public bool playergoingtohit = false;
    public bool hitpedestrian = false;
    public bool endthecamera = false;
    public bool letsevade = false;
    public bool pedestrianmoves = false;

    public bool playerenterdtrigger = false;
    public bool playerisgoingtohit = false;
    public bool timetofall = false;

    public bool playerhitspawn = false;
    public bool playerhitdestroy = false;
    

    public MainPlayerController cntller;
    public Animator anim;



    void Start()
    {
        cntller = GetComponent<MainPlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        wistile();
        if(letsevade && playerwitsled)
        {
            pedestrianmoves = true;
        }

        if (hitpedestrian)
        {

            cntller.playercanmove = false;
            cntller.playerdead = true;
            StartCoroutine(stopthecamera());
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spawnthepedestrian"))
        {
           playerhitspawn = true;
            playerhitdestroy = false;
            pedestrianmoves = false;

        }
        if (other.gameObject.CompareTag("destroypedestrian"))
        {
            playerhitdestroy = true;
            playerhitspawn = false;
            playercanwitsle = false;
            playerenterdtrigger = false;
            hitpedestrian = false;
            pedestrianmoves = false;
            playerisgoingtohit = false;
            letsevade = false;
        }
        if (other.gameObject.CompareTag("wisilesection"))
        {
            playercanwitsle = true;
            playerenterdtrigger = true;
        }
        else
        {
            playercanwitsle = false;
        }
     
        if (other.gameObject.CompareTag("Pedestrian"))
        {
            hitpedestrian = true;
        }
        else
        {
            hitpedestrian = false;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wisilesection"))
        {
            leftsection = true;
            playercanwitsle = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BadTiming"))
        {
            playerisgoingtohit = true;
        }
        else
        {
            playerisgoingtohit = false;
        }
    }


    public void wistile()
    {
        if (playerisgoingtohit)
        {
            timetofall = true;
        }
        if (!playerisgoingtohit)
        {
            if (Input.GetKeyDown(KeyCode.A) && playercanwitsle)
            {
                letsevade = true;
                playerwitsled = true;
                playercanwitsle = false;

            }           
        }
        else
        {
            letsevade = false;
            playerwitsled = false;
            playercanwitsle = true;
        }

    }
   private IEnumerator stopthecamera()
    {
        yield return new WaitForSecondsRealtime(2f);
        endthecamera = true;
    }
}
