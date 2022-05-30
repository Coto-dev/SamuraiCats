using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;
    public float speed;
    public float agroDistance;

    // Start is called before the first frame update
    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroDistance)
        {
            StartHunting();
        }
      
    }
    void StartHunting()
    {

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
        /*  if (player.position.x < transform.position.x)
          {
              physic.velocity = new Vector2(-speed, 0);
          }
          else if (player.position.y > transform.position.y)
          {
              Debug.Log("down");
              physic.velocity = new Vector2(0, speed);
          }
          else if (player.position.x > transform.position.x)
          {
              physic.velocity = new Vector2(speed, 0);

          }
          else if (player.position.y < transform.position.y)
          {
              physic.velocity = new Vector2(0, speed);
              // Debug.Log("down");
          }*/

    }

}
