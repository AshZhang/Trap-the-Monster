using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdatePit : MonoBehaviour {

	public Sprite ruined;
	public SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){	// when a pit is stepped in, it gets ruined and becomes revealed to monster
		sr.sprite = ruined;
		if (other.gameObject.tag == "monster") {
			SceneManager.LoadScene ("Win");
		}
	}
}
