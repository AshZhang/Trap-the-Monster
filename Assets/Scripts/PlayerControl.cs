using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
	public float jumpForce;
	public float vel;
	public Rigidbody2D rb;
	public CheckGround cg;

	public int maxPitJumps;
	// How many jumps the player must do in total to get out of pit
	public Text movementText;

	public SpriteRenderer sr;
	public Sprite normalSprite;
	public Sprite winSprite;
	public Sprite trappedSprite;
	public Animator anim;

	private int pitJumps;
	// How many jumps the player still has to do if they are trapped in a pit (starts at 0)

	// Use this for initialization
	void Start ()
	{
		pitJumps = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool canJump = cg.canJump();
		float horVel = 0;
		if (pitJumps > 0) {
			if (Input.GetAxis ("Jump") != 0) {
				pitJumps -= 1;
			}
			if (pitJumps == 0) {
				sr.sprite = normalSprite;
			}
		} else {
			horVel = vel * Input.GetAxis ("Horizontal");
			if (Input.GetKeyDown ("up") && canJump) {
				rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			}
			if (horVel < 0) {
				sr.flipX = true;
			}
			if (horVel > 0) {
				sr.flipX = false;
			}
			anim.SetBool ("running", cg.canJump () && Input.GetAxis("Horizontal") != 0);
			anim.SetBool ("jumping", !cg.canJump ());
		}
		rb.velocity = new Vector2 (horVel, rb.velocity.y);
		movementText.text = "Speed: " + rb.velocity + "\nJumps left: " + pitJumps + "\nCan jump: " + canJump;	// Text for debug purposes
//		Debug.DrawLine(new Vector3(transform.position.x, transform.position.y - 0.32f, 0), new Vector3(transform.position.x, transform.position.y - 0.33f, 0));
	}


	void OnCollisionEnter2D (Collision2D other)
	{
		switch (other.gameObject.tag) {
		case "monster":
			sr.sprite = winSprite;	// temporary win behavior - change player color to yellow
			break;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "pit") {	// If player is trapped in pit, they must press Space x times before they can move again
			pitJumps = maxPitJumps;
			sr.sprite = trappedSprite;
		}
	}
}
