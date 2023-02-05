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
				gameObject.SetActive(false);
				break;
			case "Enemy":
				collision.GetComponent<SpriteRenderer>().color = Color.green;
				gameObject.SetActive(false);
				break;
			case "Player":
				gameObject.SetActive(false);
				break;
			default:
				break;
		}
	}
}
