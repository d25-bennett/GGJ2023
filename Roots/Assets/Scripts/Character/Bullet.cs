using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Rigidbody2D rb;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		switch (collision.gameObject.tag)
		{
			case "Terrain":
				Destroy(gameObject);
				break;
			case "Enemy":
				Destroy(gameObject);
				break;
			default:
				break;
		}
	}
}
