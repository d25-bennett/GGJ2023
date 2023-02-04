using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
	public GameObject follow;
	public float movementTime;

    // Update is called once per frame
    void Update()
    {
		//this.transform.position = follow.transform.position;

		transform.position = Vector3.Lerp(transform.position, follow.transform.position, Time.deltaTime * movementTime);
	}
}
