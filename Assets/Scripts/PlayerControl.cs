using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public Sprite trappedSprite;
	public Animator anim;
	public int health;
	public int maxHealth;
	public int invinTime;

	private int pitJumps;
	private bool beingKbd;
	private float time;
	// How many jumps the player still has to do if they are trapped in a pit (starts at 0)

	// Use this for initialization
	void Start ()
	{
		pitJumps = 0;
		health = maxHealth;
		time = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (health <= 0) {
			SceneManager.LoadScene ("Lose");
		}
		bool canJump = cg.canJump ();

		if (beingKbd) {
			time += Time.deltaTime;
			if (time >= invinTime) {
				beingKbd = false;
			}
		}
		float horVel = 0;
		if (pitJumps > 0) {
			if (Input.GetKeyDown ("space")) {
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

			anim.SetBool ("running", canJump && Input.GetAxis ("Horizontal") != 0);
			anim.SetBool ("jumping", !canJump);
			anim.SetBool ("hurt", beingKbd);

			rb.velocity = new Vector2 (horVel, rb.velocity.y);
	
			if (horVel < 0) {
				sr.flipX = true;
			} else if (horVel > 0) {
				sr.flipX = false;
			}

		}
		movementText.text = "Speed: " + rb.velocity + "\nJumps left: " + pitJumps + "\nCan jump: " + canJump;	// Text for debug purposes
	}


	void OnCollisionStay2D (Collision2D other)
	{
		switch (other.gameObject.tag) {
		case "monster":
			if (!beingKbd) {
				damage (other.gameObject);
				beingKbd = true;
			}
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

	public void damage (GameObject other)
	{
		health -= 5;
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.01f);
		time = 0;
	}
}
