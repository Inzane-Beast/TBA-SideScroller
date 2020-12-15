using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingControl : MonoBehaviour
{
    public GameObject startpress;
    public Animator anim;
    public Animator trans;

    
    void Start()
    {
        trans = GetComponent<Animator>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("appearing", 2);
    }
    public void button()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("pressed", true);
            Invoke("movtonext", 0.5f);
        }
    }
    public void appearing()
    {
        startpress.SetActive(true);
        button();
    }
    public void movtonext()
    {
        trans.SetTrigger("FadeOut");
        SceneManager.LoadScene(1);
    }
}
