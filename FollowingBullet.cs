using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBullet : Collidable
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    public int damage = 1;
    public float pushForce = 10;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // bulletRB = GetComponent<Rigidbody2D>();
        // target = GameObject.FindGameObjectWithTag("Player");

    }

    protected override void Update()
    {
        base.Update();
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }


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

            Destroy(gameObject);
            // Send to enemy
            coll.SendMessage("ReceiveDamagePlayer", dmg);
        }
    }  


}

