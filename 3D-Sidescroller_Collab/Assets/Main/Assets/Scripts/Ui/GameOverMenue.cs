using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenue : MonoBehaviour
{
    bool gamahasended = false;

    public PlayerScore Plrscr;

    public GameObject highscoredisplay;
   
    void Start()
    {
        this.gameObject.SetActive(false);
        Plrscr = FindObjectOfType<PlayerScore>();
        highscoredisplay = GetComponent<GameObject>();
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

            if (Plrscr.Score > PlayerPrefs.GetInt("HighScore"))
            {
                GameObject.FindGameObjectWithTag("beatenHighscore").SetActive(true);
            }
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(2);
    }
    public void tomainmenue()
    {
        SceneManager.LoadScene(1);
    }
}
