using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdatePit : MonoBehaviour {

	public Sprite ruined;
	public SpriteRenderer sr;

	public AudioSource sound;

	void OnTriggerEnter2D(Collider2D other){	// when a pit is stepped in, it gets ruined and becomes revealed to monster
		sr.sprite = ruined;
		sound.Play ();
		if (other.gameObject.tag == "monster") {
			SceneManager.LoadScene ("Win");
		}
	}
}
