using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	public LayerMask ground;
	public float groundCheckRad;

	private bool onGround;

	// Use this for initialization
	void Start () {
		onGround = false;
	}

	void FixedUpdate(){
		onGround = Physics2D.OverlapCircle (new Vector2(transform.position.x, transform.position.y - gameObject.GetComponent<BoxCollider2D>().size.y / 2.0f), groundCheckRad, ground);
	}

	public bool canJump(){
		return onGround;
	}
}
