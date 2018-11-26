using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrapRadius : MonoBehaviour {

	public GameObject monster;
	public float jumpForce;

	private CheckGround cg;
	// Use this for initialization
	void Start () {
		cg = monster.GetComponent<CheckGround> ();
	}
	
	// Update is called once per frame
	void Update () {
		float xOffset = 0;
		if (monster.GetComponent<Monster> ().facingRight) {
			xOffset = 0.97f;
		} else {
			xOffset = -0.97f;
		}
		transform.position = new Vector2 (monster.transform.position.x + xOffset, monster.transform.position.y);
	}

	void OnTriggerStay2D(Collider2D other){
		switch (other.gameObject.tag) {
		case "cage":
		case "pit":
			Debug.Log ("Monster can see player: " + monster.GetComponent<Monster> ().canSeePlayer);
			if (cg.canJump () && monster.GetComponent<Monster>().canSeePlayer) {
				monster.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			}
			break;
		}
	}
}
