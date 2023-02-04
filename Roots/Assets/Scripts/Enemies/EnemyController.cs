using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movespeed = 5f;
    public float fireRate = 1f;
    public float slowdownDuration = 5.0f;
    public GameObject bulletPrefab;
    private Transform player;
    private float nextFire = 0f;
    private Rigidbody2D rb;
    private Vector2 movement;
    //public AudioClip soundClip;
    //public AudioSource audioSource;
    public float fireForce;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        //Debug.Log(direction);
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot(direction);
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
                StartCoroutine(SlowDown());
                Debug.Log("Hit by player bullet");
                break;
            case "EnemyBullet":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    private IEnumerator SlowDown()
    {
        float old_movespeed;
        //float originalSpeed = rb.velocity.magnitude;
        //rb.velocity = Vector2.zero;

        old_movespeed = movespeed;
        movespeed = 0;
        GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(slowdownDuration);
        movespeed = old_movespeed;
        GetComponent<SpriteRenderer>().color = Color.red;
        //rb.velocity = rb.velocity.normalized * originalSpeed;
    }

    void Shoot(Vector3 firePoint)
    {
        //GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        //Instantiate(bulletPrefab, transform.position, transform.rotation);
        //audioSource.clip = soundClip;
        //audioSource.Play();
    }
}

/*{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
