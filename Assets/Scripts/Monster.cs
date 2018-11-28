using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour {

	public Rigidbody2D rb;
	public bool trapped;
	public bool facingRight;	// helps MonsterTrapRadius stay on proper side of monster
	public GameObject player;
	public CheckGround cg;
	public bool canSeePlayer;	// helps MonsterTrapRadius decide when monster should jump when near trap
	public SpriteRenderer sr;
	public Animator anim;
	public float jumpForce;

	// Use this for initialization
	void Start () {
		trapped = false;
		facingRight = true;
		canSeePlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!trapped) {
			RaycastHit2D seePlayer = Physics2D.Raycast (transform.position, player.transform.position - transform.position, 2.5f);	// line of sight looking for player

			Debug.DrawRay (new Vector3 (transform.position.x, transform.position.y, 0), new Vector3 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0));
			if (seePlayer) {
				canSeePlayer = seePlayer.transform.gameObject == player;
				if (canSeePlayer) {
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
			anim.SetBool ("running", cg.canJump () && Mathf.Abs (rb.velocity.x) > 0.01);
			anim.SetBool ("jumping", !cg.canJump ());
		}
	}

	void OnCollisionEnter2D(Collision2D other){	// This collision is for the monster itself, to detect if it's fallen into a trap or touched other things
		switch (other.gameObject.tag) {
		case "cage":
		case "pit":
			SceneManager.LoadScene ("Win");
			break;
		}
	}

	public void jumpPlatform(){
		if (cg.canJump () && Mathf.Abs (rb.velocity.x) > 1) {
			rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
		}
	}

}
