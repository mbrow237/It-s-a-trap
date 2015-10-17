using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	private Rigidbody rb;
	public bool trapped;
	public bool trapContact;
	public GameObject trap;
	//public GameObject trap;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		trapContact = false;
		//trap = GameObject.FindWithTag ("Trap"); 
	}

	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);		
		rb.AddForce (movement * speed);

		if (trapContact == true) 
		{
			if(trap.GetComponent<trapController>().enemySet == true)
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
		}
	}


}