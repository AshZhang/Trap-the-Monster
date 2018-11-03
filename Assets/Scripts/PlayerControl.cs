using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

	public float vel;
	public Rigidbody2D rb;
	public float maxStamina;
	public float dashSpeed;
	public Text staminaText;

	private float stamina;
	private bool canDash;

	// Use this for initialization
	void Start ()
	{
		stamina = maxStamina;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horVel = 0;
		float verVel = 0;
		if (Input.GetAxis ("Dash") > 0 && canDash) {
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
		} else {
			if (stamina < maxStamina) {
				stamina += 0.5f;
			}else{
				canDash = true;
			}
			horVel = vel * Input.GetAxis ("Horizontal");
			verVel = vel * Input.GetAxis ("Vertical");
		}
		rb.velocity = new Vector2 (horVel, verVel);
		staminaText.text = "Stamina: " + stamina + "\nSpeed: " + rb.velocity;

	}
}
