using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool gamahasended = false;
    
    public void gameover()
    {

        if (gamahasended == false)
        {
            gamahasended = true;
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("GameOverMenue").SetActive(true);
            
        }       
    }
    public void restart()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void tomainmenue()
    {
        FindObjectOfType<AudioManager>().Play("M1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }
}
