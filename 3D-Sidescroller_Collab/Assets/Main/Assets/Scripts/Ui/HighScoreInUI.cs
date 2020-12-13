using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreInUI : MonoBehaviour
{
    public TextMeshProUGUI highscore;

    public PlayerScore plrscre;
    

    void Start()
    {
        
        plrscre = FindObjectOfType<PlayerScore>();
        highscore.text = PlayerPrefs.GetInt("HighScore",0).ToString() + "m";
       
    }

    // Update is called once per frame
    void Update()
    {
        if(plrscre.Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            
            PlayerPrefs.SetInt("HighScore", plrscre.Score);
            highscore.text = PlayerPrefs.GetInt("HighScore", plrscre.Score).ToString() + "m";
        }
        if(plrscre.Score > PlayerPrefs.GetInt("HighScore"))
        {
            GameObject.FindGameObjectWithTag("beatenHighscore").SetActive(true);
        }
        else
        {
            GameObject.FindGameObjectWithTag("beatenHighscore").SetActive(false);
        }
    }
}
