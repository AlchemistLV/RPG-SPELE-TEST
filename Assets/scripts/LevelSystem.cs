using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour {

	public Combat player;
    public EnemySpawning enSpawn;
    public SpecialAttacks spAttack1;
    public SpecialAttacks spAttack2;
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
        spAttack1.cooldown = spAttack1.cooldown * 0.9;
        spAttack2.cooldown = spAttack2.cooldown * 0.8;
        enSpawn.spawnTime = enSpawn.spawnTime * 0.9f;

    }
}
