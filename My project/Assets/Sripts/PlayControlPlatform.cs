using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class PlayControlPlatform : MonoBehaviour
{

	public enum ProjectAxis { onlyX = 0, xAndY = 1 };
	public ProjectAxis projectAxis = ProjectAxis.onlyX;
	public float speed = 150;
	public float addForce = 7;
	public bool lookAtCursor;
	public KeyCode leftButton = KeyCode.A;
	public KeyCode rightButton = KeyCode.D;
	public KeyCode upButton = KeyCode.W;
	public KeyCode downButton = KeyCode.S;
	public KeyCode addForceButton = KeyCode.Space;
	public bool isFacingRight = true;
	private Vector3 direction;
	private float vertical;
	private float horizontal;
	private Rigidbody2D body;
	private float rotationY;
	private bool jump;

	
	private float timeBtwAttack;
	public float startTimeBtwAttack;
	//public float speed;
	public int health;
	public int damage;
	private Rigidbody2D rb;
	Animator animator;
	Animator magAnim;
	//private Vector2 direction;
	private float lastPosition = 9999;
	private bool faceIsRight = true;
	public Transform attackPos;
	public Transform magic;
	public LayerMask enemy;
	public float attackRange;
	public HealthBar healthBar;

Vector2 CPoint = new Vector2(55.8f, -1.9f);

  //  class cPoint
  //  {
		//
  //      public void OnTriggerEnter2D(Collider2D cPoint)
  //      {
  //          CPoint = body.position;
  //          Debug.Log(body.position);
  //      }
  //  }

	//Vector2 cPoint = new Vector2(96f, 29f);

	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		body.fixedAngle = true;

		//CPoint = new Vector2(55.8f, -1.9f);
		if (projectAxis == ProjectAxis.xAndY)
		{
			body.gravityScale = 0;
			body.drag = 10;
		}
		Time.fixedDeltaTime = 1f / 64;
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
		{
			body.drag = 10;
			jump = true;
		}
	}


	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("cPoint"))
		{
			CPoint = body.position;
		}
		else
            if (other.CompareTag("Death"))
        {
			body.velocity = body.velocity * 0;
			body.position = CPoint;
			
		}
	}

	//		void OnTriggerEnter2D(Collider2D Death)
	//{
	//	body.position = CPoint;
	//	//Debug.Log(body.position);
	//	//body.position = new Vector2(82.87f, 40f);
	//}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
		{
			body.drag = 0;
			jump = false;
		}
	}
	
	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed);

		if (Mathf.Abs(body.velocity.x) > speed / 100f)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
		}

		if (projectAxis == ProjectAxis.xAndY)
		{
			if (Mathf.Abs(body.velocity.y) > speed / 100f)
			{
				body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed / 100f);
			}
		}
		else
		{
			if (Input.GetKey(addForceButton) && jump)
			{
				body.velocity = new Vector2(0, addForce);
			}
		}
	}

	void Flip()
	{
		if (projectAxis == ProjectAxis.onlyX)
		{
			isFacingRight = !isFacingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	void Update()
	{
		if (lookAtCursor)
		{
			Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
			lookPos = lookPos - transform.position;
			float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		if (Input.GetKey(upButton)) vertical = 1;
		else if (Input.GetKey(downButton)) vertical = -1; else vertical = 0;

		if (Input.GetKey(leftButton)) horizontal = -1;
		else if (Input.GetKey(rightButton)) horizontal = 1; else horizontal = 0;

		if (projectAxis == ProjectAxis.onlyX)
		{
			direction = new Vector2(horizontal, 0);
		}
		else
		{
			if (Input.GetKeyDown(addForceButton)) speed += addForce; else if (Input.GetKeyUp(addForceButton)) speed -= addForce;
			direction = new Vector2(horizontal, vertical);
		}

		if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
	}


}
