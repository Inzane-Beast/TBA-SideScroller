using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsmenue : MonoBehaviour
{
    public GameObject menue;
    public GameObject graphics;
    public GameObject credits;
    public GameObject sounds;
    public GameObject options;
    public GameObject settings;

    public void backtomenue()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        menue.SetActive(true);
        options.SetActive(false);
    }
    public void graphicmenue()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        graphics.SetActive(true);
        settings.SetActive(false);
       
    }
    public void creditsmenue()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        credits.SetActive(true);
        settings.SetActive(false);
    }
    public void soundsmenue()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        sounds.SetActive(true);
        settings.SetActive(false);
    }
    public void backtooptionsmenue()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        graphics.SetActive(false);
        settings.SetActive(true);
        sounds.SetActive(false);
        credits.SetActive(false);
        menue.SetActive(false);
    }
}
