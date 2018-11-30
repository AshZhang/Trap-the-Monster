using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour {

	public GameObject monster;
	public GameObject monsterTrapRadius;
	public float x;
	public float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		GameObject newMon = Instantiate (monster, new Vector2 (x, y), Quaternion.identity);
		GameObject newRadius = Instantiate (monsterTrapRadius, new Vector2 (x, y), Quaternion.identity);
		newRadius.GetComponent<MonsterTrapRadius>().monster = newMon;
		Destroy (gameObject);
	}
}
