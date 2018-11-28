using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

	//Integers
	public int curHealth;
	public int maxHealth;

	//Floats
	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;

	//Booleans
	public bool awake = true;
	public bool lookingRight = true;

	//References
	public GameObject bullet;
	public Transform target;
	public Animator anim;
	public Transform shootPointLeft, shootPointRight;

	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	void Start()
	{
		curHealth = maxHealth;
	}

	void Update()
	{
		RangeCheck();
	}

	void RangeCheck()
	{
		distance = Vector3.Distance(transform.position, target.transform.position);
		Debug.Log (distance);

		if (distance < wakeRange)
		{
			awake = true;
		}

		if (distance > wakeRange)
		{
			awake = false;
		}
	}

	public void Attack(bool attackingRight)
	{
		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval)
		{
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize();

			if (!attackingRight)
			{
				GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

				bulletTimer = 0;
			}

			if(attackingRight)
			{
				GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

				bulletTimer = 0;
			}
		}
	}
}
