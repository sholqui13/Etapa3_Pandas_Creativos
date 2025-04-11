using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingBlocks : MonoBehaviour {

	private Rigidbody m_rigidBody;

	private Vector3 originalPos;


	// Use this for initialization
	void Awake()
	{
		m_rigidBody = GetComponent<Rigidbody> ();
		m_rigidBody.freezeRotation = true;
	
		originalPos = gameObject.transform.position;
	}
		

	void FixedUpdate () 
	{		
		if (true == GameController.m_alive && true == GameController.m_finish) 
		{ // if player is still alive, reset position
			gameObject.transform.position = originalPos;
		}


	}

}

