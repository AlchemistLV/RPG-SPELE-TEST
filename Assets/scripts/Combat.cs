using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//blabla
public class Combat : MonoBehaviour {

    public GameObject enemy;
    public AnimationClip attack;
    public AnimationClip dieClip;

    public int health;
    public int minHealth;
    public int maxHealth;
    public int damage;
    public double impactTime = 0.36;
    private bool impacted;
    public float range;

	public bool inAction;
	public bool specialAttack;

    bool started;
    bool ended;
	// Use this for initialization
	void Start () {
		
		health = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
        if (!IsDead())
        {
			if (Input.GetKey (KeyCode.Mouse0) && !specialAttack) 
			{
				inAction = true;
			}
			if (inAction) {
				if (Attack (0, 1, KeyCode.Mouse0, attack)) {
				} else {
					inAction = false;
				}
			}
        }
        else
        {
            Dead();
        }
    }
	public bool Attack (int stunSeconds, double damageScale, KeyCode key, AnimationClip animClip) 
	{
		if (Input.GetKey(key) && InRange())
		{
			GetComponent<Animation>().Play(animClip.name);
			ClickToMove.attack = true;
			if (enemy != null)
			{
				transform.LookAt(enemy.transform.position);
			}
		}
		if (GetComponent<Animation>()[animClip.name].time > 0.9 * GetComponent<Animation>()[animClip.name].length)
		{
			ClickToMove.attack = false;
			impacted = false;
			if (specialAttack) {
				specialAttack = false;
			}
			return false;
		}
		Impact(stunSeconds, damageScale, animClip);
		return true;
	}
	public void ResetAttack () 
	{
		ClickToMove.attack = false;
		impacted = false;
		GetComponent<Animation> ().Stop (attack.name);
	}
    public void GetHit(double damage)
    {
		health = Mathf.Clamp(health - (int)damage, minHealth, maxHealth);
    }
    public bool IsDead()
    {
        return (health <= 0);
    }
    void Dead()
    {
        if(!ended)
        {
            GetComponent<Animation>().Play(dieClip.name);
            if (!started)
            {
               // Destroy(gameObject);
                ClickToMove.die = true;
                started = true;
                SceneManager.LoadScene("Main-Menu");
            }
            if (started && !GetComponent<Animation>().IsPlaying(dieClip.name))
            {
                //lietas kas notiek kad nomirsti
                Debug.Log("You have died!");
                ended = true;
            }
        }
    }
	void Impact(int stunSeconds, double damageScale, AnimationClip aClip)
    {
        if(enemy!=null && GetComponent<Animation>().IsPlaying(aClip.name) && !impacted)
        {
            if (GetComponent<Animation>()[aClip.name].time > GetComponent<Animation>()[aClip.name].length * impactTime && GetComponent<Animation>()[aClip.name].time < 0.9 * GetComponent<Animation>()[aClip.name].length)
            {
                enemy.GetComponent<Mob>().GetHit(damage * damageScale);
				enemy.GetComponent<Mob> ().GetStunned (stunSeconds);
                impacted = true;
            }
        }
    }
    bool InRange()
    {
        return enemy != null && (Vector3.Distance(enemy.transform.position, transform.position) <= range);
    }
}
