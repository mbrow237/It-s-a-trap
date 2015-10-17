using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {
	public Transform target;
	public Transform trans;
	public Rigidbody rb;
	public float maxSpeed;
	public float radius;
	public float timeToTarget;
	public Vector3 toTarget;
	public GameObject player;
	public Vector3 pPos;
	public Vector3 tempPos;
	public bool trapContact;
	public GameObject trap;
	
	
	
	// Update is called once per frame
	void Start(){
		trans = GetComponent<Transform> ();//Find the position of the cube
		rb = GetComponent<Rigidbody> ();//Sets the ridged body of the cube
		timeToTarget = 1f;//how long it should reach the destination
		maxSpeed = 1.0f;//the top speed of the cube
		radius = 2f;//how close the cube reach the click
		player = GameObject.FindGameObjectWithTag("Player");
		trapContact = false;

	}
	
	void Update () {

		pPos = player.GetComponent<Transform>().position;
		tempPos = pPos;
		toTarget = tempPos - trans.position;//the distanced between the cube and where the mouse is clicked
		
		if (toTarget.magnitude < radius) {
			return;
		}
		
		toTarget /= timeToTarget;//make sure the cube reaches the right speed to get to location on time
		
		if (toTarget.magnitude > maxSpeed) {
			toTarget.Normalize ();//change vector length into 1
			
			toTarget *= maxSpeed;
		}
		
		rb.velocity = toTarget;//move to where the mouse was clicked
		
		
		trans.rotation = Quaternion.Lerp (trans.rotation, Quaternion.LookRotation (toTarget), .2f);//rotate where the mouse was clicked

		if (trapContact == true) 
		{
			if(trap.GetComponent<trapController>().set == true)
			{
				Destroy(this.gameObject);
			}
		}



	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Trap")
		{
			trapContact = true;
			trap = other.gameObject;

		}
	}
	
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Trap")
		{
			trapContact = false;
			trap = null;
		}
	}
}
