using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    bool started;
    bool ended;
	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
        if (!IsDead())
        {
            if (Input.GetMouseButton(0) && InRange())
            {
                GetComponent<Animation>().Play(attack.name);
                ClickToMove.attack = true;
                if (enemy != null)
                {
                    transform.LookAt(enemy.transform.position);
                }
            }
            if (GetComponent<Animation>()[attack.name].time > 0.9 * GetComponent<Animation>()[attack.name].length)
            {
                ClickToMove.attack = false;
                impacted = false;
            }
            Impact();
        }
        else
        {
            Dead();
        }
    }
    public void GetHit(int damage)
    {
        health = Mathf.Clamp(health - damage, minHealth, maxHealth);
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
                ClickToMove.die = true;
                Destroy(gameObject);
                started = true;
            }
            if (started && !GetComponent<Animation>().IsPlaying(dieClip.name))
            {
                //lietas kas notiek kad nomirsti
                Debug.Log("You have died!");
                ended = true;
            }
        }
    }
    void Impact()
    {
        if(enemy!=null && GetComponent<Animation>().IsPlaying(attack.name) && !impacted)
        {
            if (GetComponent<Animation>()[attack.name].time > GetComponent<Animation>()[attack.name].length * impactTime && GetComponent<Animation>()[attack.name].time < 0.9 * GetComponent<Animation>()[attack.name].length)
            {
                enemy.GetComponent<Mob>().GetHit(damage);
                impacted = true;
            }
        }
    }
    bool InRange()
    {
        return enemy != null && (Vector3.Distance(enemy.transform.position, transform.position) <= range);
    }
}
