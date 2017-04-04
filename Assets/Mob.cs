using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    public float speed;
    public float range;
    public CharacterController controller;
    public Transform player;
    private Combat opponent;

    public AnimationClip attackClip;
    public AnimationClip run;
    public AnimationClip idle;
    public AnimationClip die;

    public double impactTime = 0.36;
    private bool impacted;
    public int damage;
    public int health;

    // Use this for initialization
    void Start () {

        opponent = player.GetComponent<Combat>();

	}
	
	// Update is called once per frame
	void Update () {
        if(!isDead())
        {
            if (!inRange())
            {
                chase();
            }
            else
            {
                GetComponent<Animation>().Play(attackClip.name);
                attack();

                if(GetComponent<Animation>()[attackClip.name].time > 0.9 * GetComponent<Animation>()[attackClip.name].length)
                {
                    impacted = false;
                }
            }
        }
        else
        {
            dead();
        }
	}
    void attack()
    {
        if (GetComponent<Animation>()[attackClip.name].time > GetComponent<Animation>()[attackClip.name].length * impactTime && GetComponent<Animation>()[attackClip.name].time < 0.9 * GetComponent<Animation>()[attackClip.name].length && !impacted)
        {
            opponent.getHit(damage);
            impacted = true;
        }
    }
    public void getHit(int damage)
    {
        health = health - damage;
        if(health<0)
        {
            health = 0;
        }
    }
    void dead()
    {
        GetComponent<Animation>().Play(die.name);
        if(GetComponent<Animation>()[die.name].time > 0.9 * GetComponent<Animation>()[die.name].length)
        {
            Destroy(gameObject);
        }
    }
    bool isDead()
    {
        return (health == 0);
    }
    bool inRange ()
    {
        return Vector3.Distance(transform.position, player.position) < range;
    }
    void chase ()
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
