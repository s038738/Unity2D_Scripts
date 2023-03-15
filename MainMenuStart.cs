using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStart : MonoBehaviour
{

    void Start() {
        Screen.SetResolution(800,600,true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        //GameManager.instance.inDungeon = false;
    }

    public void QuitGame()
    {

        Debug.Log("QUIT");
        Application.Quit();
    }
}
