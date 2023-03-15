using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player")
        {
            // GameManager.instance.knightMenuAnim.SetTrigger("show");
            animator.SetTrigger("show");
            Debug.Log(other.name);
            Debug.Log("show");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player")
        {
            // GameManager.instance.knightMenuAnim.SetTrigger("hide");
            animator.SetTrigger("hide");
            Debug.Log("hide");
            GameManager.instance.SaveState();
        }    
    }


        public void Arrmor_1() // price 100 ; damage 2
    {
        if (GameManager.instance.gold > 99)
        {
        GameManager.instance.health += 2;
        GameManager.instance.max_health += 2;
        GameManager.instance.gold -= 100;
        Debug.Log("yra");
      

        //TODO :uzblokuoti mygtuka greyed out batai

        }
        else
        {
            Debug.Log("truksta");
        }
    }

    public void Arrmor_2() // price 200 ; damage 3
    {
        if (GameManager.instance.gold > 199)
        {
        // GameManager.instance.player.hitpoint += 5;
        GameManager.instance.health += 5;
        GameManager.instance.max_health += 5;

        GameManager.instance.gold -= 200;
       

        

        }
        else
        {
            //ERROR truksta saibu
        }
    }

    public void Arrmor_3() // price 400 ; damage 4
    {
        if (GameManager.instance.gold > 399)
        {
        // GameManager.instance.player.hitpoint =+ 10;
        GameManager.instance.health += 10;
        GameManager.instance.max_health += 10;
        GameManager.instance.gold -= 400;
       
        }
        else
        {
            //ERROR truksta saibu
        }
    }

}
