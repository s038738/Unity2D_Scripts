using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_1 : MonoBehaviour
{

    

    private Vector3 mousePos;
    private Vector3 direction;
    private Camera mainCam;
    public int damagePoint = 0; //damage
    public float pushForce = 2.0f; //knockback
    public Transform attackPoint;
    public Animator anim;
    public float attackRange = 0.1f;
    public LayerMask enemyLayers;

    public float attackRate = 1f; //cooldown between swings
    float nextAttackTime = 0.5f;

    void Start() 
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;
        //if(Time.time >= nextAttackTime)
        //{
            if(Input.GetMouseButton(1))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        //}

       
    }

    void Attack()
    {

        float x = direction.x;
        float y = direction.y;

        if (y > 0 && y > x)
        {
            anim.SetTrigger("Swingu");
        }

        else if (y < 0 && (Mathf.Abs(y) > x))
        {
            anim.SetTrigger("Swingd");
        }

        else if (x > 0 && x > y )
        {
            anim.SetTrigger("Swinglr");
        }

        else if (x < 0 && (Mathf.Abs(x) > y))
        {
            anim.SetTrigger("Swinglr");
        }

        // if (x == 0 && y == 0)
        // {
        //     anim.SetTrigger("Swinglr");
        // }



        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
               Damage dmg = new Damage
            {
                damageAmount = damagePoint + GameManager.instance.player_damage,
                origin = transform.position,
                pushForce = pushForce
            };

            // Send to enemy
            enemy.SendMessage("ReceiveDamage", dmg);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
