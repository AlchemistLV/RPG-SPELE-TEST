using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour {

	public Combat player;
	public int level;
	public int exp;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		LevelUp ();

	}
	void LevelUp() {
		if (exp >= 100) {
			level = level + 1;
			LevelEffect ();
			player.health = player.maxHealth;
			exp = exp - 100;
		}
	}
	void LevelEffect() {
		player.maxHealth = 2 * player.maxHealth - 90;
		player.damage = 2 * player.damage - 25;
	}
}
