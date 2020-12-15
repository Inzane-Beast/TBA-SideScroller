using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
    public static bool gameispaused = false;

    public GameObject pausemenue;

    public MainPlayerController mpl;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        mpl = FindObjectOfType<MainPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !mpl.G_GameOver)
        {
            if (gameispaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
        pausemenue.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
    }
    public void pause()
    {
        pausemenue.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true;
    }
    public void tomainmenue()
    {
        SceneManager.LoadScene(0);
    }
    public void restartgame()
    {
        SceneManager.LoadScene(1);
    }
}
