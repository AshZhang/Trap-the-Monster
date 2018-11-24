using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

	public float vel;
	public Rigidbody2D rb;

	public float maxStamina;
	// How much total stamina player has
	public float dashSpeed;
	public int maxPitJumps;
	// How many jumps the player must do in total to get out of pit
	public Text staminaText;

	public SpriteRenderer sr;
	public Sprite normalSprite;
	public Sprite winSprite;
	public Sprite trappedSprite;

	private float stamina;
	private bool canDash;
	private int pitJumps;
	// How many jumps the player still has to do if they are trapped in a pit (starts at 0)

	// Use this for initialization
	void Start ()
	{
		stamina = maxStamina;
		pitJumps = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horVel = 0;
		float verVel = 0;
		if (pitJumps > 0) {
			if (Input.GetKeyDown ("space")) {
				pitJumps -= 1;
			}
			if (pitJumps == 0) {
				sr.sprite = normalSprite;
			}
		} else if (Input.GetAxis ("Dash") > 0 && canDash) {	// Player can dash briefly by pressing space - this drains stamina
			horVel = (vel + dashSpeed) * Input.GetAxis ("Horizontal");
			verVel = (vel + dashSpeed) * Input.GetAxis ("Vertical");
			if (horVel != 0 || verVel != 0) {
				stamina -= 1;
			} else if (stamina < maxStamina) {
				stamina += 0.5f;
			}
			if (stamina <= 0) {
				canDash = false;
			}
		} else {	// stamina is replenished by not dashing
			if (stamina < maxStamina) {
				stamina += 0.5f;
			} else {
				canDash = true;
			}
			horVel = vel * Input.GetAxis ("Horizontal");
			verVel = vel * Input.GetAxis ("Vertical");
		}
		rb.velocity = new Vector2 (horVel, verVel);
		staminaText.text = "Stamina: " + stamina + "\nSpeed: " + rb.velocity + "\nJumps left: " + pitJumps;	// Text for debug purposes
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "monster") {
			sr.sprite = winSprite;	// temporary win behavior - change player color to yellow
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
