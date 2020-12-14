using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsBeckOption : MonoBehaviour
{
    public GameObject optionbarl;
    public GameObject mainsettings;

    public void backtoprevious()
    {
        optionbarl.SetActive(false);
        mainsettings.SetActive(true);
        FindObjectOfType<AudioManager>().Play("M1");

    }
}
