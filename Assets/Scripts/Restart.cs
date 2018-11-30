using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public SpriteRenderer sr;
	public Sprite begin;
	public Sprite play;
	public Sprite replay;
	public Sprite next;

	public LevelController lc;
	public SpriteRenderer titleScreen;
	public Sprite instructions;

	void Start(){
		lc = GameObject.Find ("level controller").GetComponent<LevelController>();
		switch (SceneManager.GetActiveScene ().name) {
		case "Menu":
			titleScreen = GameObject.Find ("title instructions").GetComponent<SpriteRenderer> ();
			sr.sprite = begin;
			break;
		case "Lose":
			sr.sprite = replay;
			break;
		case "Win":
			if (lc.level == 4) {
				sr.sprite = replay;
			} else {
				sr.sprite = next;
			}
			break;
		}
	}

	void OnMouseDown(){
		switch(SceneManager.GetActiveScene().name){
		case "Menu":
			if (sr.sprite == begin) {
				sr.sprite = play;
				titleScreen.sprite = instructions;
			} else if (sr.sprite == play) {
				SceneManager.LoadScene ("Level 1");
			}
			break;
		case "Lose":
			Destroy (lc.gameObject);
			SceneManager.LoadScene ("Menu");
			break;
		case "Win":
			if (lc.level == 4) {
				Destroy (lc.gameObject);
				SceneManager.LoadScene ("Menu");
			} else {
				lc.level++;
				SceneManager.LoadScene ("Level " + (lc.level));
			}
			break;
		}
	}
}
