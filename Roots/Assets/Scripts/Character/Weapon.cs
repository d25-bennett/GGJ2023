using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public GameObject bullet;
	public Transform firePoint;
	public AudioSource audioData;
	public AudioClip pew;
	public float fireForce;

	private void Start()
	{
		audioData = GetComponent<AudioSource>();
	}

	public void Fire()
	{
		GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
		//GameObject projectile = ObjectPool.SharedInstance.GetPooledObject();
		if (projectile != null)
		{
			projectile.transform.position = firePoint.position;
			projectile.transform.rotation = firePoint.rotation;
			audioData.PlayOneShot(pew); 
		}
		projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
	}
}
