using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float vel;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float horVel = vel * Input.GetAxis ("Horizontal");
		float verVel = vel * Input.GetAxis ("Vertical");
		rb.velocity = new Vector2 (horVel, verVel);
	}
}
