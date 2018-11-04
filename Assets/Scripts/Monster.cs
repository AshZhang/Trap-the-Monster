using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public Rigidbody2D rb;
	public bool trapped;

	// Use this for initialization
	void Start () {
		trapped = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){	// This collision is for the monster itself, to detect if it's fallen into a trap
		if (other.gameObject.tag == "cage" || other.gameObject.tag == "pit") {
			Debug.Log ("Monster is trapped!");
			rb.velocity = Vector2.zero;
			trapped = true;
		}
	}
}
