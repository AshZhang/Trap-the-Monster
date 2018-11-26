using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public Rigidbody2D rb;
	public bool trapped;
	public bool facingRight;
	public GameObject player;
	public CheckGround cg;
	public bool canSeePlayer;
	public SpriteRenderer sr;
	public Animator anim;

	// Use this for initialization
	void Start () {
		trapped = false;
		facingRight = true;
		canSeePlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D obj = Physics2D.Raycast (transform.position, player.transform.position - transform.position, 2.5f);
		Debug.DrawRay (new Vector3 (transform.position.x, transform.position.y, 0), new Vector3 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0));
		if (obj) {
			//Debug.Log ("Monster saw: " + obj.transform.gameObject);
			canSeePlayer = obj.transform.gameObject == player;
			if (canSeePlayer) {		// Current monster behavior - move away when player approaches...
				Debug.Log ("Saw player");
				float xDiff = transform.position.x - player.transform.position.x;
				facingRight = xDiff > 0;
				xDiff = xDiff / Mathf.Abs (xDiff);
				rb.velocity = new Vector2 (xDiff * 4, rb.velocity.y);
			}
		} else if (cg.canJump ()) {
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}
		if (rb.velocity.x > 0) {
			sr.flipX = false;
		} else if (rb.velocity.x < 0) {
			sr.flipX = true;
		}
		anim.SetBool ("running", cg.canJump () && Mathf.Abs(rb.velocity.x) > 0.01);
		anim.SetBool ("jumping", !cg.canJump ());
	}

	void OnTriggerEnter2D(Collider2D other){	// This collision is for the monster itself, to detect if it's fallen into a trap
		if (other.gameObject.tag == "cage" || other.gameObject.tag == "pit") {
			Debug.Log ("Monster is trapped!");
			rb.velocity = Vector2.zero;
			trapped = true;
		}
	}

}
