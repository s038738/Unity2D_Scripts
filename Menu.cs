using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text goldText, experienceText, healthText, speedText, damageText, maxHealth;
    private static GameObject instance;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
           instance = gameObject;
        else
           Destroy(gameObject);
    }

    void Update() 
    {
        healthText.text = GameManager.instance.health.ToString();
    }


    public void UpdateMenu()
    {
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
        goldText.text = GameManager.instance.gold.ToString();
        experienceText.text = GameManager.instance.experience.ToString();
        healthText.text = GameManager.instance.health.ToString();
        speedText.text = GameManager.instance.speed.ToString();
        damageText.text = GameManager.instance.player_damage.ToString();
        maxHealth.text = GameManager.instance.max_health.ToString();
    }


    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }



    


}
