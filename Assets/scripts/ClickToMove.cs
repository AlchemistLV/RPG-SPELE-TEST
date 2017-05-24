using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToMove : MonoBehaviour {
	public float speed;
    public CharacterController Controller;
	private Vector3 position;

    public AnimationClip run;
    public AnimationClip idle;
    public static bool attack;
    public static bool die;
	// Use this for initialization
	void Start () {
        position = transform.position;
        die = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main-Menu");
        }
        if(!attack && !die)
        {
            if (Input.GetMouseButton(1))
            {
                LocatePosition();
            }
            MoveToPosition();
        }
        else
        {

        }
	}

	void LocatePosition () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 1000)) {
            if(hit.collider.tag!="Player" && hit.collider.tag!="Enemy")
            {
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
		}
	}

	void MoveToPosition () {
        if(Vector3.Distance(transform.position, position)>1) {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);
            newRotation.x = 0f;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            Controller.SimpleMove(transform.forward * speed);
            GetComponent<Animation>().Play(run.name);
        }
		else
        {
            GetComponent<Animation>().Play(idle.name);
        }
	}
}
