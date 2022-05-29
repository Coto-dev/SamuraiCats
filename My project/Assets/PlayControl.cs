using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //direction.x = (rb.velocity.x - direction.x) * speed;
        //direction.y = (rb.velocity.y - direction.y) * speed;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        //Vector2 moveInput = new Vector2(moveInput.GetAxis("Horizontal"), moveInput.GetAxis("Vertical"));
        //moveVelocity = moveInput * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
