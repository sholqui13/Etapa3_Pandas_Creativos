using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float m_speed = 15.0f;
	private float m_jumpSpeed = 35.0f;
	private float m_horizontal;
	private float m_vertical;
	private bool  m_jump;
	private bool m_isGrounded;
	private float m_moreGravity = 100.0f; 

	private Rigidbody m_rigidBody;

	void Awake() 
	{
		m_rigidBody = GetComponent<Rigidbody> ();
		Vector3 vel = m_rigidBody.linearVelocity;
		vel.y = m_moreGravity*Time.deltaTime;
		m_rigidBody.linearVelocity = vel; 

		m_rigidBody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * m_speed;
		m_vertical = Input.GetAxis ("Vertical") * Time.deltaTime * m_speed;
		transform.Translate (m_horizontal, 0, m_vertical);

		if (m_isGrounded) {
			if (Input.GetKeyDown (KeyCode.Space)) {  // jump if on ground
				m_rigidBody.linearVelocity = Vector3.up * m_jumpSpeed;
			}
		} else {
			Vector3 vel = m_rigidBody.linearVelocity;
			vel.y-=m_moreGravity*Time.deltaTime;
			m_rigidBody.linearVelocity=vel;
		}



	}
		
	void OnCollisionStay (Collision collisionInfo) // for jumping info
	{
		m_isGrounded = true;
	}

	void OnCollisionExit (Collision collisionInfo)
	{
		m_isGrounded = false;
	}
		
}
