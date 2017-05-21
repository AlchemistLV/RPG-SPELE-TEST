using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttacks : MonoBehaviour {

	public Combat player;
	public KeyCode key;
    public AnimationClip attackClip;
    public double damagePerc;
	public int stunTime;
    public double cooldown;
    public double cooldownTime;
    private bool onCD;
	public bool inAction;

	// Use this for initialization
	void Start () {

        onCD = false;
        cooldownTime = cooldown;
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (key) && !player.specialAttack && !onCD) 
		{
			player.ResetAttack ();
			player.specialAttack = true;
			inAction = true;
        }
		if (inAction) 
		{
			if (player.Attack (stunTime, damagePerc, key, attackClip)) {	
			} else {
				inAction = false;
                InvokeRepeating("OnCoolDown", 0f, 0.1f);
            }
		}
	}
    public void CoolDown()
    {
        cooldownTime = cooldown;
        InvokeRepeating("OnCoolDown", 0f, 0.1f);

    }
    void OnCoolDown()
    {
        cooldownTime = cooldownTime - 0.1;
        if (cooldownTime <= 0)
        {
            onCD = false;
            cooldownTime = cooldown;
            CancelInvoke("OnCoolDown");
        }
        else
        {
            onCD = true;
        }
    }
}
