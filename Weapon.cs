using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage struct
    public int damagePoint = 0; //damage
    public float pushForce = 2.0f; //knockback

    //Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing
    private Animator anim;
    private float cooldown = 0.5f; //cooldown between swings
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetMouseButton(0))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

            // Create damage, and send
            Damage dmg = new Damage
            {
                damageAmount = damagePoint + GameManager.instance.player_damage,
                origin = transform.position,
                pushForce = pushForce
            };

            // Send to enemy
            coll.SendMessage("ReceiveDamage", dmg);
            
        }
    }

    public void Swing()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (y > 0)
        {
            anim.SetTrigger("Swingu");
        }

        if (y < 0)
        {
            anim.SetTrigger("Swingd");
        }

        if (x > 0)
        {
            anim.SetTrigger("Swinglr");
        }

        if (x < 0)
        {
            anim.SetTrigger("Swinglr");
        }

        if (x == 0 && y == 0)
        {
            anim.SetTrigger("Swinglr");
        }
    }
}
