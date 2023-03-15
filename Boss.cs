using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Mover
{
    public float speed = 1.2f;
    private Transform player;
    private Vector3 startingPosition;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float lineofSite;
    public float fireRate = 1f;
    private float nextFireTime;

    public float shootfireRate = 1f;
    private float shootnextFireTime;
    public GameObject bullet1;
    public GameObject bulletParentShoot;

    private Animator anim;

    // Xp
    public int xpValue = 1;

    // Hitbox    
    public ContactFilter2D filter;
    private Collider2D[] hits = new Collider2D[10];
    private BoxCollider2D hitbox;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineofSite)
        {
            UpdateMotorEnemy((player.position - transform.position).normalized * speed);
        }
        else
        {
            UpdateMotorEnemy(new Vector3(0, 0, 0));
        }

        if (hitpoint < 100)
        {
        if (distanceFromPlayer < lineofSite && nextFireTime < Time.time)
        {
            UpdateMotorEnemy(new Vector3(0, 0, 0));
            anim.SetTrigger("attack");
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
            
        }

        if (hitpoint < 50)
        {
            speed = 0.4f;
        if (distanceFromPlayer < lineofSite && shootnextFireTime < Time.time)
        {
            anim.SetTrigger("attack");
            Instantiate(bullet1, bulletParentShoot.transform.position, Quaternion.identity);
            shootnextFireTime = Time.time + shootfireRate;
        }
            
        }


        

        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
                
            if(hits[i].name == "Player")
            {
            }
            hits[i] = null;
        }

    }


    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experience += xpValue;
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineofSite); // Sight
    }

}
