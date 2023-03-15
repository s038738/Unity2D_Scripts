using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player")
        {
            // GameManager.instance.frogMenuAnim.SetTrigger("show");
            animator.SetTrigger("show");
            Debug.Log(other.name);
            Debug.Log("show");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player")
        {
            // GameManager.instance.frogMenuAnim.SetTrigger("hide");
            animator.SetTrigger("hide");
            Debug.Log("hide");
            GameManager.instance.SaveState();
        }    
    }

    public void Boots_1() // price 60 ; speed 1.1
    {
        if (GameManager.instance.gold > 59)
        {
        GameManager.instance.speed = 1.1f;
        GameManager.instance.gold -= 60;
      

        //TODO :uzblokuoti mygtuka greyed out batai

        }
        else
        {
            //ERROR truksta saibu
        }
    }

    public void Boots_2()
    {
        if (GameManager.instance.gold > 139)
        {
        GameManager.instance.speed = 1.2f;
        GameManager.instance.gold -= 140;
       

        

        }
        else
        {
            //ERROR truksta saibu
        }
    }

    public void Boots_3()
    {
        if (GameManager.instance.gold > 239)
        {
        GameManager.instance.speed = 1.3f;
        GameManager.instance.gold -= 240;
       

        

        }
        else
        {
            //ERROR truksta saibu
        }
    }
}
