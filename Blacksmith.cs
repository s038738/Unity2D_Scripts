using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    public Animator animator;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player")
        {
            //GameManager.instance.blacksmithMenuAnim.SetTrigger("show");
            animator.SetTrigger("show");
            Debug.Log(other.name);
            Debug.Log("show");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player")
        {
            // GameManager.instance.blacksmithMenuAnim.SetTrigger("hide");
            animator.SetTrigger("hide");
            Debug.Log("hide");
            GameManager.instance.SaveState();
            
        }    
    }

    public void Sword_1() // price 100 ; damage 2
    {
        if (GameManager.instance.gold > 99)
        {
        GameManager.instance.player_damage = 2;
        GameManager.instance.gold -= 60;
      

        //TODO :uzblokuoti mygtuka greyed out batai

        }
        else
        {
            //ERROR truksta saibu
        }
    }

    public void Sword_2() // price 200 ; damage 3
    {
        if (GameManager.instance.gold > 199)
        {
        GameManager.instance.player_damage = 3;
        GameManager.instance.gold -= 200;
       

        

        }
        else
        {
            //ERROR truksta saibu
        }
    }

    public void Sword_3() // price 400 ; damage 4
    {
        if (GameManager.instance.gold > 399)
        {
        GameManager.instance.player_damage = 4;
        GameManager.instance.gold -= 400;
       

        

        }
        else
        {
            //ERROR truksta saibu
        }
    }
}


