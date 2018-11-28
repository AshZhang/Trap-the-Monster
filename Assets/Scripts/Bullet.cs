﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.isTrigger != true)
		{
			if (col.CompareTag("player"))
			{
				Destroy(gameObject);
				// add damage to player
			}
		}
	}
}
