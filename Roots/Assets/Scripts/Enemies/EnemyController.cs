using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movespeed = 1f;
    private float normalSpeed;
    public float fireRate = 1f;
    public float slowdownDuration = 5.0f;

    private Transform player;
    private float nextFire = 0f;  
    private Rigidbody2D rb;
    private Vector2 movement;
	public Weapon weapon;
	[SerializeField]
	private GameObject vine;
	private GameObject newVine;
	public ScoreUI ui;

	private bool frozen;

	//public AudioClip soundClip;
	//public AudioSource audioSource;


	void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
		//audioSource = GetComponent<AudioSource>();
		normalSpeed = movespeed;
		fireRate = Random.Range(1, 5);
	}

    void Update()
    {
		if (!frozen)
		{
			Vector3 direction = player.position - transform.position;

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			rb.rotation = angle; //TODO Bad fix, but it works for now.
			direction.Normalize();
			movement = direction;

			if (Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				Shoot(direction);
				fireRate = Random.Range(1, 5);
			}
		}
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
				if (newVine != null)
					Destroy(newVine);
                StartCoroutine(SlowDown());
                Debug.Log("Hit by player bullet");
                break;
            case "Enemy Bullet":
                Debug.Log("Hit by enemy bullet");
				ui.UpdateScore(100);
				Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    private IEnumerator SlowDown()
    {
		// Freezes enemy in place
		frozen = true;
        movespeed = 0;
        GetComponent<SpriteRenderer>().color = Color.green;
		// Spawn vines below enemy
		newVine = Instantiate(vine);
		newVine.transform.position = gameObject.transform.position;
		newVine.transform.SetParent(gameObject.transform);
		yield return new WaitForSeconds(slowdownDuration);
		// Remove vines below enemy
		Destroy(newVine);
		// Unfreezes enemy
		movespeed = normalSpeed;
        GetComponent<SpriteRenderer>().color = Color.white;
		frozen = false;
    }


	public void Shoot(Vector3 target)
    {
        Debug.Log("Shoot");
		weapon.Fire();
    }
	
}