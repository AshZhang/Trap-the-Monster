using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public int level = 1;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("v")) {
			SceneManager.LoadScene ("Win");
		}
		if (Input.GetKeyDown ("x")) {
			SceneManager.LoadScene ("Lose");
		}
	}
}
