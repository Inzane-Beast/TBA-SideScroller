using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenue : MonoBehaviour
{
    bool gamahasended = false;
   
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
    }
    public void gameover()
    {

        if (gamahasended == false)
        {
            gamahasended = true;
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("GameOverMenue").SetActive(true);

        }
    }
    public void restart()
    {
        SceneManager.LoadScene(1);
    }
    public void tomainmenue()
    {
        SceneManager.LoadScene(0);
    }
}
