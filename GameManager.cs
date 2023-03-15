using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {

        Screen.SetResolution(800,600,true);
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // Reference
    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;
    public Menu menu;
    public HUD hud;

    // Logic
    public int gold;
    public int experience;
    public int health = 10;
    public int max_health = 10;
    public float speed = 1.0f;
    public int player_damage = 1;
    public bool in_heal_area = false;
    public bool inDungeon = false;

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Save state
    /*
     INT preferedSkin
     INT gold
     INT experience
     INT weaponLevel
     */



    public void SaveState()
    {
        Debug.Log("SaveState");

        string s = "";

        s += "0" + "|";
        s += gold.ToString() + "|";
        s += experience.ToString() + "|";
        s += speed.ToString() + "|";
        s += player_damage.ToString() + "|";
        s += health.ToString() + "|";
        s += max_health.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
       

    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        // "0|10|15|2" 

        //TODO: change preferedSkin
        gold = int.Parse(data[1]);
        experience= int.Parse(data[2]);
        speed= float.Parse(data[3]);
        player_damage= int.Parse(data[4]);
        health= int.Parse(data[5]);
        max_health= int.Parse(data[6]);
        //TODO: add weaponLevel xp
        Debug.Log("LoadState");


        if (GameObject.Find("SpawnPoint") == null)
        {
            return;
        }
        else
        {
            player.transform.position = GameObject.Find("SpawnPoint").transform.position;
        }

        if (GameManager.instance.player_damage == 0)
        {
            GameManager.instance.player_damage = 1;
        }


        




    }

}
