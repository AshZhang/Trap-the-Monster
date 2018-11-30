using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	public PlayerControl player;


	void Start()
	{
		player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerControl>();
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag("player"))
		{
			player.damage(this.gameObject);
		}
	}
}
