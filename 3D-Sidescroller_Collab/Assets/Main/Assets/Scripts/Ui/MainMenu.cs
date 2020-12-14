using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menue;
    public GameObject options;
    public void Start()
    {
        Time.timeScale = 1;
    }
    public void playGame()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void quitGame()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        Application.Quit();
    }

    public void optionsmenu()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        menue.SetActive(false);
        options.SetActive(true);

    }
}
