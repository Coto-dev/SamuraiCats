using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayControl : MonoBehaviour
{
    
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float speed;
    public int health;
    public int damage;
    private Rigidbody2D rb;
    Animator animator;
    Animator magAnim;
    Animator magAnimWater;
    private Vector2 direction;
    private float lastPosition = 9999;
    private bool faceIsRight = true;
    public Transform attackPos;
    public Transform magic;
    public Transform magicWater;
    public LayerMask enemy;
    public float attackRange;
    public HealthBar healthBar;
    private float timer = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(500);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        magAnim = magic.GetComponent<Animator>();
        magAnimWater = magicWater.GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            magAnim.SetTrigger("Fire");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            magAnimWater.SetTrigger("Fire");
        }
        if (health <= 0)
        {
            animator.Play("DieOrFall");
            timer -= Time.deltaTime;
            if (timer <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void FixedUpdate()
    {
        

        if (timeBtwAttack <= 0)
        {
            
            if (Input.GetMouseButton(0))
            {
                
                animator.SetBool("attack1",true);
                animator.SetBool("Walk", false);
                animator.SetBool("idle", false);
                timeBtwAttack = startTimeBtwAttack;
               

            }
            else if (Input.GetMouseButton(1))
            {
                animator.SetBool("attack2", true);
                animator.SetBool("Walk", false);
                animator.SetBool("idle", false);
                timeBtwAttack = startTimeBtwAttack;
                
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        if (health > 0)
        {
            Walk();
            Flip();
        }
      /*  if (health <= 0)
        {
            animator.Play("DieOrFall");
            timer -= Time.deltaTime;
            if (timer <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        animator.SetTrigger("hurt");
    }
    public void Attack1()
    {
        
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        Debug.Log("enemies  " + enemies.Length);
        for (int i = 0; i < enemies.Length; i++)
        {
            try
            {
                enemies[i].GetComponent<EnemyControl>().TakeDamage(damage*2);
            }
            catch
            {
                enemies[i].GetComponent<BossControl>().TakeDamage(damage*2);

            }
        }
        Debug.Log("EEEEEEEEEEEEEEEEEEEEEEEEE");
        animator.SetBool("attack1", false);
        animator.SetBool("attack2", false);

    }
    public void Attack2()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        Debug.Log("enemies  " + enemies.Length);
        for (int i = 0; i < enemies.Length; i++)
        {
            Debug.Log("enemies  " + enemies[i]);
            try
            {
                enemies[i].GetComponent<EnemyControl>().TakeDamage(damage);
            }
            catch
            {
                enemies[i].GetComponent<BossControl>().TakeDamage(damage);

            }
        }
        Debug.Log("EEEEEEEEEEEEEEEEEEEEEEEEE");
        animator.SetBool("attack1", false);
        animator.SetBool("attack2", false);

    }
    void Walk()
    {
        
        float inputX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float inputY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        rb.velocity = new Vector2(inputX, inputY);

        if (inputY != 0 || inputX != 0)
        {
            animator.SetBool("attack1", false);
            animator.SetBool("attack2", false);
            animator.SetBool("Walk", true);
          //  animator.SetBool("attack1", false);
          //  animator.SetBool("attack2", false);
        }
        else
        {
            //Debug.Log("faceIsRight  " + faceIsRight);
            animator.SetBool("Walk", false);
            
            animator.SetBool("idle", true);
           // transform.localScale = new Vector2(-0.25f, 0.25f);
        }

      /* if (lastPosition == 9999)
            lastPosition = transform.position.x;*/

        if (transform.position.x > lastPosition)
        {
          //  Debug.Log("faceIsRight" + faceIsRight);
            faceIsRight = true;
            Debug.Log("faceIsRight   " + faceIsRight);
        }
        else if (transform.position.x < lastPosition)
        {
            Debug.Log("faceIsRight   " + faceIsRight);
            faceIsRight = false;

        }
       // Debug.Log("faceIsRight   " + faceIsRight);
       // Debug.Log("lastPosition   " + lastPosition);
       // Debug.Log("transform.position.x   " + transform.position.x);
        lastPosition = transform.position.x;
    }
   void Flip()
    {
        if (faceIsRight)
        {
           // Debug.Log("SWAPPPPPPP   " + faceIsRight);
            transform.localScale = new Vector2(0.25f, 0.25f);
        }
        else
        {
           // Debug.Log("SWAPPPPPPP   " + faceIsRight);
            transform.localScale = new Vector2(-0.25f, 0.25f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


    bool playgame = true;
     private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape)){
        if (playgame == true){
            Time.timeScale = 0f;
            SceneManager.LoadScene(3);
            playgame = false;
        }
        else{
            Time.timeScale = 1f;
            playgame = true;
        }

      }

    }
    
}
