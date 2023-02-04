using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public GameObject bullet;
	public Transform firePoint;
	public float fireForce;
	
	public void Fire()
	{
		//GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
		GameObject projectile = ObjectPool.SharedInstance.GetPooledObject();
		if (projectile != null)
		{
			projectile.transform.position = firePoint.position;
			projectile.transform.rotation = firePoint.rotation;
			projectile.SetActive(true);
		}
		projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
	}
}
