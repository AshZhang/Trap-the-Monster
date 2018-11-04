﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterRadius : MonoBehaviour
{

	public GameObject monster;

	private bool runningAway;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = monster.transform.position;
	}

	void OnTriggerStay2D (Collider2D other)		// This radius is for "seeing" the player
	{
		if (!monster.GetComponent<Monster>().trapped) {		// Current monster behavior - move away when player approaches...
			if (other.gameObject.tag == "player") {
				Vector2 dirToPlayer = transform.position - other.gameObject.transform.position;
				dirToPlayer.Normalize ();
				monster.GetComponent<Rigidbody2D> ().velocity = dirToPlayer * 4;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		monster.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;	// ...and do nothing if player is not nearby
	}
}
