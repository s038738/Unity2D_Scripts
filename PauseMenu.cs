using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static  bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject DeathMenuUI;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } 
        if (GameManager.instance.health == 0)
        {
            GameIsPaused = true;
            GameManager.instance.inDungeon = false;
            DeathMenu();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void LoadMenu()
    {
       SceneManager.LoadScene("MainMenu");
       GameIsPaused = true;
       Time.timeScale = 1f;

       if (GameManager.instance.inDungeon)
       {
        DeathMenuUI.SetActive(false);
       }
       

    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }

    public void DeathMenu()
    {
        Time.timeScale = 0f;
        DeathMenuUI.SetActive(true);

    }


}
