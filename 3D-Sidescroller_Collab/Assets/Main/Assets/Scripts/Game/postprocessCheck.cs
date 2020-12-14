using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postprocessCheck : MonoBehaviour
{
    [HideInInspector]
    public GraphicsMenu grpmen;

    public GameObject Postprocessing;
    void start()
    {
        grpmen = FindObjectOfType<GraphicsMenu>();

        //  if(grpmen.PostProcessEnabled == true)
        //   {
        //         Postprocessing.SetActive(true);
        //   }
        //   else
        //    {
        //        Postprocessing.SetActive(false);
        //   }


        if (PlayerPrefs.GetInt("Post") >= 0)
        {
            Postprocessing.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Post") == 1)
        {
            Postprocessing.SetActive(false);
        }

    }
}
