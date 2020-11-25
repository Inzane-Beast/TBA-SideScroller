using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float scorecount;
    public int Score;

    public float scorePerSecond = 10;

    public int minimumlevellimit = 50;
    public int maxlevelLimit = 10000;
    public float p_speedincrease = 0.005f;
    public int levelLimitIntervel = 50;

    public bool increaselevel = false;


    
 
    void Start()
    {
        
    }

   
    void Update()
    {
        scorecount += scorePerSecond * Time.deltaTime;
        Score = (int)scorecount;

        if(Score == minimumlevellimit && Score <= maxlevelLimit)
        {
            increaselevel = true;
            minimumlevellimit = minimumlevellimit + levelLimitIntervel;
        }
        else
        {
            increaselevel = false;
        }
    }
}
