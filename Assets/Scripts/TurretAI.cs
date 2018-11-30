using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{

	//Floats
	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;

	//Booleans
	public bool lookingRight = true;

	//References
	public GameObject bullet;
	public Transform target;
	public Transform shootPointLeft, shootPointRight;

	public SpriteRenderer sr;
	public AudioSource sound;

	public void Attack (bool attackingRight)
	{
		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval) {
			sound.Play ();
			Vector2 direction = target.position - transform.position;
			GameObject bulletClone;
			if (!attackingRight) {
				bulletClone = Instantiate (bullet, shootPointLeft.transform.position, Quaternion.Euler(new Vector3(0, 0, Mathf.Rad2Deg *  Mathf.Atan(direction.y / direction.x)))) as GameObject;
				sr.flipX = false;
			} else {
				bulletClone = Instantiate (bullet, shootPointRight.transform.position,  Quaternion.Euler(new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan(direction.y / direction.x)))) as GameObject;
				sr.flipX = true;
			}
			direction.Normalize ();

			bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			bulletTimer = 0;
		}
	}
}
