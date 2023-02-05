using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Camera sceneCam;
	public float moveSpeed;
	private Vector2 moveDir;
	private Vector2 mousePos;
	public Rigidbody2D rb;

	public Weapon weapon;

<<<<<<< Updated upstream
	public int health;
	
=======
	public float knockbackForce = 5f;


>>>>>>> Stashed changes
	private void Update()
	{
		Inputs();
	}

	private void FixedUpdate()
	{
		Move();
	}

	void Inputs()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		if (Input.GetMouseButtonDown(0))
		{
			weapon.Fire();
		}

		moveDir = new Vector2(moveX, moveY).normalized;
		mousePos = sceneCam.ScreenToWorldPoint(Input.mousePosition);
	}

	void Move()
	{
		rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);

		Vector2 aimDir = mousePos - rb.position;
		float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;

		rb.rotation = aimAngle;
	}

<<<<<<< Updated upstream
=======
	//Take Damage
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if((collision.gameObject.tag == "Enemy") || (collision.gameObject.tag == "EnemyBullet"))
		{
			Debug.Log("Player Collision");
			if (!damageCooldown)
			{
				health--;
				hUI.UpdateUIHealth();
				// Do a loop counting for a timer for i-frames
				//Knockback
				/*Rigidbody2D playerRb = GetComponent<Rigidbody2D>();
				if (playerRb != null)
				{
					Vector2 knockbackDirection = (playerRb.position - (Vector2)GetComponent<Collider>().transform.position).normalized;
					playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
				}*/
			}
		}
	}

>>>>>>> Stashed changes
}
