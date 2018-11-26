using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterRadius : MonoBehaviour
{

	public GameObject monster;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = monster.transform.position;
	}

	void OnTriggerStay2D (Collider2D other)		// This radius is for "seeing" the player
	{
		if (!monster.GetComponent<Monster>().trapped) {		// Current monster behavior - move away when player approaches...
			if (other.gameObject.tag == "player") {
				float xDiff = monster.transform.position.x - other.gameObject.transform.position.x;
				monster.GetComponent<Monster>().facingRight = xDiff > 0;
				xDiff = xDiff / Mathf.Abs (xDiff);
				Rigidbody2D rb = monster.GetComponent<Rigidbody2D> ();
				rb.velocity = new Vector2(xDiff * 4, rb.velocity.y);
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		monster.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;	// ...and do nothing if player is not nearby
	}
}
