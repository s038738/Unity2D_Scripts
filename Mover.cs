using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected Vector3 moveDelta1;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

    Animator animator;

    protected virtual void Start()

    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }


    protected virtual void UpdateMotorEnemy(Vector3 input) 
    {
        // Reset MoveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);
        moveDelta1 = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        // Swap sprite direction, left or right
        if(moveDelta.x < 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);

        
        // Add push vector if any
        moveDelta += pushDirection;

        // Reduce push force every frame, based off recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);


        // casting a box y direction first, to check movibility (null = move)
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // moving Player
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);

            
            
        }
        if(moveDelta1.y == 0)
        {
            animator.SetBool("isMoving", false);
            // animator.SetBool("isMovingUp", false);
            // animator.SetBool("isMovingDown", false);
        }
        
        // if (moveDelta1.y > 0)
        // {
        //     //animator.SetBool("isMovingDown", false);
        //     animator.SetBool("isMovingUp", true);
        // }
        
        // if (moveDelta1.y < 0)
        // {
        //     //animator.SetBool("isMovingUp", false);
        //     animator.SetBool("isMovingDown", true);
        // }
        


        // casting a box x direction first, to check movibility (null = move)
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // moving player_0
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            
        }

        if(moveDelta1.x == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
    }

}
