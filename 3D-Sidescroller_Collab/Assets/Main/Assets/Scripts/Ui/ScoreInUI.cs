using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreInUI : MonoBehaviour
{
    
    public TextMeshProUGUI scores;  
    

    public PlayerScore plrscre;
    

    void Start()
    {
        plrscre = FindObjectOfType<PlayerScore>();
        
        
       
    }
   
    void Update()
    {
        scores.text = plrscre.Score.ToString() + "m";
               
    }
}
