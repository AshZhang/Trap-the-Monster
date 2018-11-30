using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "monster") {
			Debug.Log ("used force");
			Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D> ();
			rb.AddForce (new Vector2(rb.velocity.x, 10), ForceMode2D.Impulse);
		}
	}
}
