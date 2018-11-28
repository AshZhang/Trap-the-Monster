using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

	public Slider healthBar;
	public Text healthText;
	public PlayerControl player;

	// Use this for initialization
	void Start ()
	{
		healthBar.wholeNumbers = true;
		healthBar.value = player.health;
		healthText.text = "HP: " + player.health;
	}
	
	// Update is called once per frame
	void Update ()
	{
		healthBar.value = player.health;
		healthText.text = "HP: " + player.health;
	}
}
