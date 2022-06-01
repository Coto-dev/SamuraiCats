using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayControl : MonoBehaviour
{
    
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float speed;
    public int health;
    public int damage;
    private Rigidbody2D rb;
    Animator animator;
    private Vector2 direction;
   private Vector2 lastDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float inputX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float inputY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        rb.velocity = new Vector2(inputX, inputY);

        if (inputY !=0 || inputX !=0)
        {
            animator.SetBool("Walk",true);
        }
        else
        {
            transform.localScale = new Vector2(0.25f, 0.25f);
            animator.SetBool("Walk", false);
           
        }

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        if (direction.x > lastDirection.x)
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
            lastDirection = direction;
        }
        else if (direction.x < lastDirection.x)
        {
            transform.localScale = new Vector2(-0.5f, 0.5f);
            lastDirection = direction;
        }
        else if (direction.y < lastDirection.y)
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
            lastDirection = direction;

        }
        else if (direction.y > lastDirection.y)
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
            lastDirection = direction;
        }


        if (health <= 0)
        {
            Destroy(gameObject);
        }
        //Vector2 moveInput = new Vector2(moveInput.GetAxis("Horizontal"), moveInput.GetAxis("Vertical"));
        //moveVelocity = moveInput * speed;
    }
   
}
