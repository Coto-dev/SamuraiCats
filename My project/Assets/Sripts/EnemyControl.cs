using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;
    public float speed;
    public float agroDistance;
    Animator animator;
    int attackRange = 1;
    public int health;
    public int damage;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private PlayControl player1;
    // Start is called before the first frame update
    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player1 = FindObjectOfType<PlayControl>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
       
         if(Math.Abs(transform.position.x - player.position.x) < attackRange && Math.Abs(transform.position.y - player.position.y) < attackRange)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Walk", false);
        }
       else if (distToPlayer < agroDistance)
        {
            StartHunting();
        }
        else if (distToPlayer > agroDistance)
        {
            StopHunting();
        }

    }
    void StopHunting()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Idle", true);
        animator.SetBool("Attack", false);
    }
    void StartHunting()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", true);
        //physic.MovePosition(physic.position + direction * speed * Time.fixedDeltaTime);
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);

        }
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
      
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                animator.SetBool("Attack", true);
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void onEnemyAttack()
    {
        player1.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }

}
