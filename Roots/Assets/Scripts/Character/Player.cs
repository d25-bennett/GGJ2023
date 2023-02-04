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

	public int health;
	
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

}
