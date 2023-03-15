using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShootingEnemy : Mover
{
    private Transform player;
    private Vector3 startingPosition;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;
    private float nextFireTime;

    private Animator anim;

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
        
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        { 
        anim.SetTrigger("attack");
        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
        nextFireTime = Time.time + fireRate;
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
        Gizmos.DrawWireSphere(transform.position, shootingRange); // Shooting range
    }
}
