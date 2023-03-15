using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    // Damage
    public int damage = 1;
    public float pushForce = 10;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            // Create a new damage object, before sending it to the player
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            // Send to enemy
            coll.SendMessage("ReceiveDamagePlayer", dmg);
        }
    }    
}

