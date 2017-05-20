using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    public float speed;
    public float range;
    public CharacterController controller;
    public Transform player;
    private Combat opponent;
	public LevelSystem playerLevel;

    public AnimationClip attackClip;
    public AnimationClip run;
    public AnimationClip idle;
    public AnimationClip die;

    public double impactTime = 0.36;
    private bool impacted;
    public int damage;
    public int health;
    public int minHealth;
    public int maxHealth;

	private int stunTime;

    // Use this for initialization
    void Start () {

        opponent = player.GetComponent<Combat>();

	}
	
	// Update is called once per frame
	void Update () {
        if(!IsDead())
        {
			if (stunTime <= 0) {
				if (!InRange ()) {
					Chase ();
				} else {
					GetComponent<Animation> ().Play (attackClip.name);
					Attack ();

					if (GetComponent<Animation> () [attackClip.name].time > 0.9 * GetComponent<Animation> () [attackClip.name].length) {
						impacted = false;
					}
				}
			}
        }
        else
        {
            Dead();
        }
	}
    void Attack()
    {
        if (GetComponent<Animation>()[attackClip.name].time > GetComponent<Animation>()[attackClip.name].length * impactTime && GetComponent<Animation>()[attackClip.name].time < 0.9 * GetComponent<Animation>()[attackClip.name].length && !impacted)
        {
            opponent.GetHit(damage);
            impacted = true;
        }
    }
    public void GetHit(double damage)
    {
		health = Mathf.Clamp(health - (int)damage, minHealth, maxHealth);
    }
    void Dead()
    {
        GetComponent<Animation>().Play(die.name);
        if(GetComponent<Animation>()[die.name].time > 0.9 * GetComponent<Animation>()[die.name].length)
        {
			playerLevel.exp = playerLevel.exp + 35;
            Destroy(gameObject);
        }
    }
    bool IsDead()
    {
        return (health == 0);
    }
    bool InRange ()
    {
        return Vector3.Distance(transform.position, player.position) < range;
    }
	public void GetStunned(int seconds) 
	{
		stunTime = seconds;
		InvokeRepeating ("StunCountDown", 0f, 1f);

	}
	void StunCountDown() 
	{
		stunTime = stunTime - 1;
		if (stunTime <= 0) {
			CancelInvoke ("StunCountDown");
		}
	}
    void Chase ()
    {
        transform.LookAt(player.position);
        controller.SimpleMove(transform.forward * speed);
        GetComponent<Animation>().CrossFade(run.name);
    }
    void OnMouseOver()
    {
        player.GetComponent<Combat>().enemy = gameObject;
    }
}
