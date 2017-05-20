using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttacks : MonoBehaviour {

	public Combat player;
	public KeyCode key;
	public double damagePerc;
	public int stunTime;
	public bool inAction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (key) && !player.specialAttack) 
		{
			player.ResetAttack ();
			player.specialAttack = true;
			inAction = true;
		}
		if (inAction) 
		{
			if (player.Attack (stunTime, damagePerc, key)) {	
			} else {
				inAction = false;
			}
		}
	}
}
