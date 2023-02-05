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
	[SerializeField]
	private bool damageCooldown = false;
	public HealthUI hUI;

	public AudioSource audio;
	public AudioClip damage;

	
	public float knockbackForce = 5f;


		
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

	// Grabs enemy GO to then only move around them?
	//GameObject currentEnemy;
	//void GetEnemyID(GameObject enemy)
	//{
	//	currentEnemy = enemy;
	//}

	void Move()
	{
		rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);

		Vector2 aimDir = mousePos - rb.position;
		float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

		rb.rotation = aimAngle;
	}

	//Take Damage
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy Bullet")
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
				audio.PlayOneShot(damage);
			}
			StartCoroutine(Iframes());
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
	

	private IEnumerator Iframes()
	{
		damageCooldown = true;
		yield return new WaitForSeconds(1);
		damageCooldown = false;
	}

}
