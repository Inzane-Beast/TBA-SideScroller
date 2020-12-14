using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsMenu : MonoBehaviour
{
    public GameObject postprocess;
    public bool PostProcessEnabled = true;

    public int value = 1;

    public void togglepostpro()
    {
       if(PostProcessEnabled == true)
        {
            postprocess.SetActive(false);
            PostProcessEnabled = false;
            value = 1;
        }
       else if(PostProcessEnabled == false)
        {
            postprocess.SetActive(true);
            PostProcessEnabled = true;
            value = 0;
        }
        PlayerPrefs.SetInt("Post", value);
    }
}
