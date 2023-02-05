using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField]
	private Camera sceneCam;
	[SerializeField]
	private Rigidbody2D rb;

	[SerializeField]
	private float moveSpeed;
	private Vector2 moveDir;
	private Vector2 mousePos;

	public Weapon weapon;
	
	[SerializeField]
	private int health;
	[HideInInspector]
	public int GetHealth() { return health; }
	private bool damageCooldown;
	public HealthUI hUI;

	
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
		// Gets input from user
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		if (Input.GetMouseButtonDown(0))
		{
			weapon.Fire();
		}

		// Takes the inputs and adds it into Vectors
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

	//Take Damage
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
		{
			if (!damageCooldown)
			{
				health--;
				hUI.UpdateUIHealth();
				if (health == 0)
				{
					// UI game over screen
					Destroy(this);
				}

				// Do a loop counting for a timer for i-frames
			}
		}
		if (collision.gameObject.tag == "Health")
		{
			health++;
		}
		if (collision.gameObject.tag == "EXP")
		{
			// TODO: Implement xp system?
		}
	}

}
