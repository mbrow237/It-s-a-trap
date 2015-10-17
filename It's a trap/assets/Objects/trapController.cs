using UnityEngine;
using System.Collections;

public class trapController : MonoBehaviour {
	public bool set = false;
	public bool enemySet = false;
	public bool contact = false;
	public bool trapContact;
	public Material[] materials = new Material[3];
	public Renderer rend;
	void Awake (){
	}

	void Start () {
		trapContact = false;
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (trapContact == true && (Input.GetKey("space")) && enemySet == false)
		    {
			set = true;
		}
		if (set == true)
		{
			rend.sharedMaterial = materials[1];
		}
		if (enemySet == true) {
			rend.sharedMaterial = materials[2];
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			trapContact = true;

		}
		if (other.gameObject.tag == "Enemy" && set == false) {
			enemySet = true;
		}
	}
	
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			trapContact = false;

		}
	}



}
