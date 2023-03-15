using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potion : MonoBehaviour
{

    Image m_Image;
    //Set this in the Inspector
    public Sprite m_Sprite;
    public Sprite u_Sprite;
    private bool canUse = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if ((canUse == false) && (GameManager.instance.in_heal_area == true))
        {
            canUse = true;
            Refill();
        }
    }
    public void ChangeSprite()
    {
        m_Image.sprite = m_Sprite; 
    }

    public void Refill()
    {
        m_Image.sprite = u_Sprite; 
    }

    public void heal()
    {
        if (((GameManager.instance.health) < GameManager.instance.max_health) && canUse)
        {
            if ((GameManager.instance.max_health - GameManager.instance.health) <= 3)
            {
                GameManager.instance.health = GameManager.instance.max_health;
            }
            else
            {
                GameManager.instance.health += 3;
            }
            GameManager.instance.SaveState();
            canUse = false;
            ChangeSprite();
        }
        
    }
}
