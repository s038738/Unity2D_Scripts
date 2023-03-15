using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Collidable
{
    Animator animator;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public AudioSource hit_sound;
    // public GameObject hit_sound;
    //public CameraShake shake;
    //public Animator shake;

    public int damagePoint = 0; //damage
    public float pushForce = 1.0f; //knockback

    // Start is called before the first frame update
    protected override void Start()
    {
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();

        animator = GetComponent<Animator>();
        //hit_sound = GetComponent<AudioSource>();

        base.Start();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //mainCam = GameManager.instance.mainCamera;
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 90);

        
        Destroy(this.gameObject, 2);
        //hit_sound.SetActive(false);
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            //shake.CamShake();
            hit_sound.Play();
            if (coll.name == "Player" && coll.tag == "Player") {
                return;
            }
            // Create damage, and send
            Damage dmg = new Damage
            {
                damageAmount = damagePoint + GameManager.instance.player_damage,
                origin = transform.position,
                pushForce = pushForce
            };
            
            animator.SetTrigger("explode");

            // Send to enemy
            coll.SendMessage("ReceiveDamage", dmg);
            
            transform.position = Vector3.one * -9999f;

            while(!hit_sound.isPlaying)
            {
                Destroy(gameObject);
            }                                                      
        }
        else if (coll.tag == "Collision")
        {
            animator.SetTrigger("explode");
            Destroy(gameObject);
            //hit_sound = GetComponent<AudioSource>();
        }
    }
        
}
