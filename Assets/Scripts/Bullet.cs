using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Transform player;

	void Start(){
		player = GameObject.Find ("player").transform;
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.25f);
	}

	void Update(){
		if (transform.position.x < -12 || transform.position.x > 12 || transform.position.y > 10 || transform.position.y < -10) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "player")
		{
			col.gameObject.GetComponent<PlayerControl> ().damage (gameObject);
		}
		Destroy(gameObject);
	}
}
