using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text goldText, experienceText, healthText;
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

    // Update is called once per frame
    public void Update()
    {
        goldText.text = GameManager.instance.gold.ToString();
        experienceText.text = GameManager.instance.experience.ToString();
        healthText.text = GameManager.instance.health.ToString();
        
    }
}
