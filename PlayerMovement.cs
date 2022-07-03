using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementgood : MonoBehaviour {

	public CharacterController controller;

	public float speed = 12f;
	public Transform groundcheck;
	public float GroundDistance = 0.4f;
	public LayerMask groundmask;
	public float jumpheight = 3f;

	public float gravity = -9.81f;

	Vector3 velocity;
	private bool isGrounded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics.CheckSphere(groundcheck.position , GroundDistance, groundmask);
		
		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
		}

		controller.Move(move * speed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
		
	}

	public void Jump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
		}
	}



	
	
}
