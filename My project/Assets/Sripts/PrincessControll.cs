using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class PrincessControll : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;
    public float speed;
    public float followDistance;
    public float followRange;
    Animator animator;
    public int health;
    private PlayControl player1;

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player1 = FindObjectOfType<PlayControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (Math.Abs(transform.position.x - player.position.x) < followRange && Math.Abs(transform.position.y - player.position.y) < followRange)
        {
            animator.SetBool("idle", true);
            animator.SetBool("Walk", false);
        }
      else  if (distToPlayer < followDistance)
        {
            StartHunting();
        }
        else if (distToPlayer > followDistance)
        {
            StopHunting();
        }

    }
    void StopHunting()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("idle", true);
    }
    void StartHunting()
    {
        animator.SetBool("idle", false);
        animator.SetBool("Walk", true);
        //physic.MovePosition(physic.position + direction * speed * Time.fixedDeltaTime);
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.25f, 0.25f);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-0.25f, 0.25f);

        }
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
        }
    }
}
