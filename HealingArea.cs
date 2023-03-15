using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player")
        {
            GameManager.instance.health = GameManager.instance.max_health;
            GameManager.instance.in_heal_area = true;
            Debug.Log("in");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player")
        {
            GameManager.instance.in_heal_area = false;
            GameManager.instance.SaveState();
        }    
    }
}
